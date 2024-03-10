using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public ViewResult Index(int productPage = 1)
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
    //same view for create or edit product
    //for create we need call this action without parameter
    public async Task<IActionResult> CreateOrUpdate(long? id = 0)
    {
        Product product;
        if (id == 0)
        {
            product = new();
        }
        else
        {
            product = await storeRepository.Products.FirstOrDefaultAsync(p => p.ProductID == id) ?? new();
            //product = await storeRepository.Products.FindAsync(id);
        }
        //return PartialView("ProductForm",newProduct);
        return View("ProductForm", product);
        //if (id == null)
        //{
        //    return NotFound();
        //}
        //else
        //{      
    }
}
