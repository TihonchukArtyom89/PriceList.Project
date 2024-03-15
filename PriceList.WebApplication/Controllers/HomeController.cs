using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //ViewBag.DataInPopUpNotValid = false;
        ViewBag.Categories = FillCategoriesDropdownList();
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
    public IActionResult Create()
    {
        Product product = new();
        return PartialView("ProductFrom", product);
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {//write unit tests for this action
        if (ModelState.IsValid)
        {
            storeRepository.CreateProduct(product);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            //ViewBag.DataInPopUpNotValid = true;
            //ViewBag.NotValidDataInPopup = product;
            //return RedirectToAction("Index", "Home");
            //return View("Index", new ProductsListViewModels()
            //{
            //    Products = storeRepository.Products.OrderBy(p => p.ProductID).Skip((1 - 1) * PageSize).Take(PageSize),
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = 1,
            //        ItemsPerPage = PageSize,
            //        TotalItems = storeRepository.Products.Count()
            //    }
            //});////отображение новосозданной главной страницы 
            return PartialView("ProductForm", product);//происходит отрисовка частичного представления как целого
        }
    }
    private List<SelectListItem> FillCategoriesDropdownList()
    {
        List<SelectListItem> categories = new();
        categories.Add(new SelectListItem { Text = "Выберите из списка", Value = null });
        List<Category> _categories = storeRepository.Categories.ToList();
        foreach (Category c in _categories ?? new())
        {
            categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });
        }
        return categories;
    }
}
