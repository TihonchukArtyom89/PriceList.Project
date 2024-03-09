using Microsoft.AspNetCore.Mvc;
using PriceList.WebApplication.Models;
using PriceList.WebApplication.Models.ViewModels;

namespace PriceList.WebApplication.Controllers;

public class HomeController : Controller
{
    private IStoreRepository storeRepository;
    public int PageSize = 4;

    public HomeController(IStoreRepository _storeRepository)
    {
        storeRepository = _storeRepository;
    }

    public ViewResult Index(int productPage=1)
    {
        //return View(_storeRepository.Products.OrderBy(p=>p.ProductID).Skip((productPage-1)*PageSize).Take(PageSize));
        return View(new ProductsListViewModels
        {
            Products = storeRepository.Products.OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
            PagingInfo = new PagingInfo 
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = storeRepository.Products.Count()  
            }
        }); 
    }
    public IActionResult CreateProduct()
    {
        Product newProduct = new();
        return PartialView("ProductForm",newProduct);
    }
}
