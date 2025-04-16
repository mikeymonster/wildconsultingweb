using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using WildConsulting.Web.Pages;

namespace WildConsulting.Web.Tests;

public class IndexPageTests(WebApplicationFactory<IndexModel> fixture) : IClassFixture<WebApplicationFactory<IndexModel>>
{
    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly WebApplicationFactory<IndexModel> _fixture = fixture;

    [Fact]
    public async Task Get_Index_Returns_Expected_Page()
    {
        using var client = _fixture.CreateClient();

        var result = await client.GetAsync("/");

        result.EnsureSuccessStatusCode();

        var pageContent = await result.Content.ReadAsStringAsync();
        pageContent.Should().Contain("<title>Wild Consulting Limited - Home page</title>");

        //pageContent.Should().Contain("<h1>Wild Consulting Limited</h1>");
        //var regex = new Regex("<h1\\s+\">Wild Consulting Limited</h1>");
        var regex = new Regex("<h1.*>Wild Consulting Limited</h1>");
        regex.IsMatch(pageContent).Should().BeTrue();
    }
}
