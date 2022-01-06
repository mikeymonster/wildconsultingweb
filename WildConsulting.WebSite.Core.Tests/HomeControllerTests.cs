using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WildConsulting.WebSite.Core.Controllers;
using Xunit;

namespace WildConsulting.WebSite.Core.Tests;

public class HomeControllerTests
{
    [Fact]
    public void HomeController_Index_Should_Return_ViewResult()
    {
        var controller = new HomeController();

        var result = controller.Index();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult?.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult?.ViewData.ModelState.ErrorCount.Should().Be(0);
    }

    [Fact]
    public void HomeController_About_Should_Return_ViewResult()
    {
        var controller = new HomeController();

        var result = controller.About();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult?.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult?.ViewData.ModelState.ErrorCount.Should().Be(0);
    }
        
    [Fact]
    public void HomeController_Contact_Should_Return_ViewResult()
    {
        var controller = new HomeController();

        var result = controller.Contact();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult?.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult?.ViewData.ModelState.ErrorCount.Should().Be(0);
    }
}