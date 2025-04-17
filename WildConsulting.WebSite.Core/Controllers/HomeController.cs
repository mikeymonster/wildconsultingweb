using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WildConsulting.WebSite.Core.ViewModels;

namespace WildConsulting.WebSite.Core.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        var emailAddress = _configuration["ContactSettings:Email"];
        var vm = new ContactViewModel(emailAddress);
        return View(vm);
    }
}