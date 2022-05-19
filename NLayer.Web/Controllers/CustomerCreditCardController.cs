using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Web.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NLayer.Web.Controllers
{
    public class CustomerCreditCardController : Controller
    {
        private readonly ICustomerCreditCardService _service;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public CustomerCreditCardController(ICustomerCreditCardService service, ICustomerService customerService, IMapper mapper, IHttpClientFactory httpClient)
        {
            _service = service;
            _customerService = customerService;
            _mapper = mapper;
            _httpClient = httpClient.CreateClient("Payzee");
        }

        public async Task<List<Payzee>> GetToken()
        {
            var payzee = new Payzee
            {
                password = "bS3!eG8!",
                lang = "tr",
                email = "murat.karayilan@dotto.com.tr"
                
            };
            
            var requestContent = new StringContent(JsonSerializer.Serialize(payzee), Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync("Securities/authenticationMerchant", requestContent).ConfigureAwait(false);

            var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            var jsonString = JsonSerializer.Deserialize<PayzeeResponse>(response);

            return jsonString.Result;
        }
        
        public async Task<IActionResult> Index()
        {
            return View( await _service.GetCustomerCreditCardsWithCustomer());
        }

        public async Task<IActionResult> Save()
        {
            var customers = await _customerService.GetAllAsync();
            var customersDto =  _mapper.Map<List<CustomerDto>>(customers.ToList());
            ViewBag.customers = new SelectList(customersDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerCreditCardDto customerCreditCardDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<CustomerCreditCard>(customerCreditCardDto));
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllAsync();
            var customersDto =  _mapper.Map<List<CustomerDto>>(customers.ToList());
            ViewBag.customers = new SelectList(customersDto, "Id", "Name");

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<CustomerCreditCard>))]
        public async Task<IActionResult> Update(int id)
        {
            var customerCreditCard = await _service.GetByIdAsync(id);
            
            var customers = await _customerService.GetAllAsync();
            var customersDto =  _mapper.Map<List<CustomerDto>>(customers.ToList());
            ViewBag.categories = new SelectList(customersDto, "Id", "Name", customerCreditCard.CustomerId);

            return View(_mapper.Map<CustomerCreditCardDto>(customerCreditCard));
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(CustomerCreditCardDto customerCreditCardDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<CustomerCreditCard>(customerCreditCardDto));
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllAsync();
            var customersDto =  _mapper.Map<List<CustomerDto>>(customers.ToList());
            ViewBag.customers = new SelectList(customersDto, "Id", "Name", customerCreditCardDto.CustomerId);

            return View(customerCreditCardDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var customerCreditCard = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customerCreditCard);

            return RedirectToAction(nameof(Index));
        }
    }
}