using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WildConsulting.WebSite.Core.ViewModels;

namespace WildConsulting.WebSite.Core.Controllers;

public class HomeController(IConfiguration configuration) : Controller
{
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
        var emailAddress = configuration["ContactSettings:Email"];
        var vm = new ContactViewModel(emailAddress);
        return View(vm);
    }
}