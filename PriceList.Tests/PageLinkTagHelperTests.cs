using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PriceList.WebApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Tests;


public class PageLinkTagHelperTests
{
    [Fact]
    public void Can_Generate_Page_Links()
    {
        //Arrange
        Mock<IUrlHelper> urlHelper = new();
        urlHelper.SetupSequence(x=> x.Action(It.IsAny<UrlActionContext>())).Returns("Test/Page1").Returns("Test/Page2").Returns("Test/Page3");
        Mock<IUrlHelperFactory> urlHelperFactory = new();
        urlHelperFactory.Setup(f => f.GetUrlHelper(It.IsAny<ActionContext>())).Returns(urlHelper.Object);
        Mock<ViewContext> viewContext = new();
        PageLinkTagHelper pageLinkTagHelper = new(urlHelperFactory.Object)
        {
            PageModel = new WebApplication.Models.ViewModels.PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10,
            },
            ViewContext = viewContext.Object,
            PageAction = "Test"
        };
        TagHelperContext tagHelperContext = new(new TagHelperAttributeList (),new Dictionary<object,object>(),"");
        Mock<TagHelperContent> tagHelperContent = new();
        TagHelperOutput tagHelperOutput = new("div",new TagHelperAttributeList(), (cache,encoder)=> Task.FromResult(tagHelperContent.Object));
        //Act
        pageLinkTagHelper.Process(tagHelperContext, tagHelperOutput);
        //Assert
        Assert.Equal(@"<a href=""Test/Page1"">1</a><a href=""Test/Page2"">2</a><a href=""Test/Page3"">3</a>", tagHelperOutput.Content.GetContent());
    }
}
