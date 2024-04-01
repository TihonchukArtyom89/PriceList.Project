using Microsoft.AspNetCore.Mvc;

namespace PriceList.WebApplication.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    public string Invoke()
    {
        return "Call nav view component";
    }
}
