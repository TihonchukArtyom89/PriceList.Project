using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PriceList.WebApplication.Models.ViewModels;

namespace PriceList.WebApplication.Infrastructure;

[HtmlTargetElement("div",Attributes ="page-model")]
public class PageLinkTagHelper:TagHelper
{
    private IUrlHelperFactory urlHelperFactory;
    public PageLinkTagHelper(IUrlHelperFactory _urlHelperFactory)
    {
        urlHelperFactory = _urlHelperFactory;
    }
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }   
    public PagingInfo? PageModel { get; set; }
    public string? PageAction { get; set; }
    public bool PageClassesEnabled { get; set; }=false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;

    public override void Process(TagHelperContext context,TagHelperOutput tagHelperOutput)
    {
        if(ViewContext != null && PageModel != null)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder resultTag = new("div");
            for(int i = 1; i <= PageModel.TotalPages;i++)
            {
                TagBuilder tagLink = new("a");
                tagLink.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                if(PageClassesEnabled) 
                {
                    tagLink.AddCssClass(PageClass);
                    tagLink.AddCssClass(i==PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tagLink.InnerHtml.Append(i.ToString());
                resultTag.InnerHtml.AppendHtml(tagLink);
            }
            tagHelperOutput.Content.AppendHtml(resultTag.InnerHtml);
        }
    }
}
