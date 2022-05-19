using System.Dynamic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Web.KPSPublic;

namespace NLayer.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerCreditCardService _service;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerController> _logger;

    
    public CustomerController(ICustomerService customerService, IMapper mapper, ICustomerCreditCardService service, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _mapper = mapper;
        _service = service;
        _logger = logger;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View( await _customerService.GetAllAsync());
    }
    
    public Task<IActionResult> Save()
    {
        return Task.FromResult<IActionResult>(View());
    }
    
    [HttpPost]
    public async Task<IActionResult> Save(CustomerDto customerDto)
    {
        if (ModelState.IsValid)
        {
            var isValid = await OnGet(customerDto).ConfigureAwait(false);
            if (isValid)
            {
                customerDto.IdentityNoVerified = true;
            }
            await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));
            return RedirectToAction(nameof(Index));
        }

        return View();
    }
    
    public async Task<bool> OnGet(CustomerDto customerDto)
    {
        var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
        var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(customerDto.IdentityNo), customerDto.Name, customerDto.Surname, customerDto.BirthDate);
        var result = response.Body.TCKimlikNoDogrulaResult;
        _logger.LogInformation(@"Human: {1}", (string) customerDto.IdentityNo.ToString());
        
        return result;
    }
    
    public async Task<IActionResult> Remove(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        await _customerService.RemoveAsync(customer);

        return RedirectToAction(nameof(Index));
    }
}