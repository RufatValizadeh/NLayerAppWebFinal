using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Web.KPSPublic;

namespace NLayer.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<bool> OnGet()
    {
        var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
        dynamic human = new ExpandoObject();
        human.Name = "EYNAR";
        human.LastName = "HAJI";
        human.DocumentNo = 99607335226;
        human.BirthdayYear = 1994;

        var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(human.DocumentNo), human.Name,
            human.LastName, human.BirthdayYear);
        var result = response.Body.TCKimlikNoDogrulaResult;

        _logger.LogInformation(@"Human: {1}", (string)human.DocumentNo.ToString());
        return result;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(ErrorViewModel errorViewModel)
    {
        return View(errorViewModel);
    }
}