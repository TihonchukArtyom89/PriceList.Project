using Microsoft.AspNetCore.Mvc;
using PriceList.WebApplication.Models;

namespace PriceList.WebApplication.Controllers;

public class HomeController : Controller
{
    private IStoreRepository _storeRepository;
    public int PageSize = 4;

    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public ViewResult Index(int productPage=1)
    {
        return View(_storeRepository.Products.OrderBy(p=>p.ProductID).Skip((productPage-1)*PageSize).Take(PageSize));
    }
}
