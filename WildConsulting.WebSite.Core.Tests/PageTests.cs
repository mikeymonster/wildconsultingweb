using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using WildConsulting.WebSite.Core.Pages;
using Xunit;

namespace WildConsulting.WebSite.Core.Tests;
public class PageTests : IClassFixture<WebApplicationFactory<IndexModel>>
{
    private readonly WebApplicationFactory<IndexModel> _fixture;
    public PageTests(WebApplicationFactory<IndexModel> factory)
    {
        _fixture = factory;
    }

    [Fact]
    public async Task Get_Index_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();
        
        var result = await client.GetAsync("/");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - Home page</title>");
        pageContent.Should().Contain("<h1>Wild Consulting Limited</h1>");

    }

    [Fact]
    public async Task Get_About_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();

        var result = await client.GetAsync("/about");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - About page</title>");
        pageContent.Should().Contain("<h1>About us</h1>");
    }

    [Fact]
    public async Task Get_Contact_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();

        var result = await client.GetAsync("/contact");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - Contact page</title>");
        pageContent.Should().Contain("<h1>Contact us</h1>");
    }

    [Fact]
    public async Task Get_Apps_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();

        var result = await client.GetAsync("/apps");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - Apps</title>");
        pageContent.Should().Contain("<h1>Our apps</h1>");
    }
    
    [Fact]
    public async Task Get_Error_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();

        var result = await client.GetAsync("/error");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - Error</title>");
        pageContent.Should().Contain("<h1 class=\"text-danger\">Error</h1>");
    }
}
