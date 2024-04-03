using Microsoft.AspNetCore.Mvc;
using PriceList.WebApplication.Models;

namespace PriceList.WebApplication.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IStoreRepository storeRepository;
    public NavigationMenuViewComponent(IStoreRepository _storeRepository)
    {
        storeRepository = _storeRepository;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(storeRepository.Categories.Select(c => c.CategoryName).OrderBy(c => c));
    }
}
