using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriceList.WebApplication.Models;

namespace PriceList.WebApplication.Views.Home;

public class CategoryListModel : PageModel
{
    //private IStoreRepository storeRepository;
    //public CategoryListModel(IStoreRepository _storeRepository)
    //{ 
    //    storeRepository = _storeRepository;
    //}
    //public List<Category> Categories { get; set; } = new();
    public void OnGet()
    {
        //Categories = storeRepository.Categories.ToList();   
    }
}
