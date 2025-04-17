using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WildConsulting.WebSite.Core.Controllers;
using WildConsulting.WebSite.Core.ViewModels;

namespace WildConsulting.WebSite.Core.Tests;

public class HomeControllerTests
{
    private const string TestEmailAddress = "my.email@test.com";

    private readonly Mock<IConfiguration> _mockConfiguration;

    public HomeControllerTests()
    {
        _mockConfiguration = new Mock<IConfiguration>();
        _mockConfiguration
            .SetupGet(x => x["ContactSettings:Email"])
            .Returns(TestEmailAddress);
    }

    [Fact]
    public void HomeController_Index_Should_Return_ViewResult()
    {
        var controller = new HomeController(_mockConfiguration.Object);

        var result = controller.Index();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult.ViewData.ModelState.ErrorCount.Should().Be(0);
    }

    [Fact]
    public void HomeController_About_Should_Return_ViewResult()
    {
        var controller = new HomeController(_mockConfiguration.Object);

        var result = controller.About();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult.ViewData.ModelState.ErrorCount.Should().Be(0);
    }
        
    [Fact]
    public void HomeController_Contact_Should_Return_ViewResult()
    {
        var controller = new HomeController(_mockConfiguration.Object);

        var result = controller.Contact();

        result.Should().NotBeNull();
        result.Should().BeOfType<ViewResult>();

        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult.ViewData.ModelState.IsValid.Should().BeTrue();
        viewResult.ViewData.ModelState.ErrorCount.Should().Be(0);

        viewResult.ViewData.Model.Should().BeAssignableTo<ContactViewModel>();
        var viewModel = viewResult.ViewData.Model as ContactViewModel;
        viewModel.Should().NotBeNull();
        viewModel.Email.Should().Be(TestEmailAddress);
    }
}