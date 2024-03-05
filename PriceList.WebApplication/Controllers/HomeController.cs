using Microsoft.AspNetCore.Mvc;

namespace PriceList.WebApplication.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
