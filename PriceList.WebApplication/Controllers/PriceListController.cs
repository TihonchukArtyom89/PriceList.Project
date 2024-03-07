using Microsoft.AspNetCore.Mvc;
using PriceList.WebApplication.Models;
using PriceList.WebApplication.Models.ViewModels;

namespace PriceList.WebApplication.Controllers;

public class PriceListController:Controller
{
    private IPredpriyatieRepository predpriyatieRepository;
    public int PageSize = 4;
    public PriceListController(IPredpriyatieRepository _predpriyatieRepository)
    {
        predpriyatieRepository = _predpriyatieRepository;
    }

    public IActionResult ListOfPriceLists(int productPage = 1)
    {
        return View(new ListOfPriceListsViewModels
        {
            PriceLists = predpriyatieRepository.PriceLists.OrderBy(p => p.PriceListID).Skip((productPage - 1) * PageSize).Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = predpriyatieRepository.PriceLists.Count()
            }
        });
    }
}
