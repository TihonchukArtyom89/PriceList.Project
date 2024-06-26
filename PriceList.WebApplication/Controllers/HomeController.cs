﻿using Microsoft.AspNetCore.Mvc;
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
    public ViewResult Index(string? category,int productPage = 1)
    {
        ViewBag.Categories = FillCategoriesDropdownList();
        Category? selectedCategory = storeRepository.Categories.Where(c=>c.CategoryName == category).FirstOrDefault() ?? null;
        int totalItems = 0;
        if(category == null)
        {
            totalItems = storeRepository.Products.Count();
        }
        else
        {
            totalItems = storeRepository.Products.Where(p => p.CategoryID == selectedCategory.CategoryID).Count();
        }
        return View(new ProductsListViewModels
        {
            Products = storeRepository.Products
            .Where(p => selectedCategory == null || p.CategoryID == selectedCategory.CategoryID)
            .OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = totalItems//category == null ? storeRepository.Products.Count() : storeRepository.Products.Where(p => p.CategoryID == selectedCategory.CategoryID).Count()
            },
            CurrentCategory=selectedCategory?.CategoryName
        });
    }
    public IActionResult Create()
    {
        Product product = new();
        return PartialView("AddProductFrom", product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {   
        if (ModelState.IsValid)
        {
            storeRepository.CreateProduct(product);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return PartialView("AddProductForm", product);
        }
    }
    private List<SelectListItem> FillCategoriesDropdownList()
    {
        List<SelectListItem> categories = new()
        {
            new SelectListItem { Text = "Выберите из списка", Value = "" }
        };
        List<Category> _categories = storeRepository.Categories.ToList();
        foreach (Category c in _categories ?? new List<Category>())
        {
            categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });
        }
        return categories;
    }
}
