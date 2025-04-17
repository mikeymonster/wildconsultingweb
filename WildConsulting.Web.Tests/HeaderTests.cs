using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net.Mime;
using WildConsulting.Web.Pages;

namespace WildConsulting.Web.Tests;

public class HeaderTests(WebApplicationFactory<IndexModel> factory) : IClassFixture<WebApplicationFactory<IndexModel>>
{
    // ReSharper disable once ReplaceWithPrimaryConstructorParameter
    private readonly WebApplicationFactory<IndexModel> _fixture = factory;

    [Fact]
    public async Task Get_Default_Page_Returns_Expected_Headers()
    {
        var client = _fixture.CreateClient();

        var response = await client.GetAsync("/");

        response.EnsureSuccessStatusCode();

        response.Content.Headers.ContentType.Should().NotBeNull();
        response.Content.Headers.ContentType!.MediaType.Should().Be(MediaTypeNames.Text.Html);

        //response.Headers.Should().ContainKey("Feature-Policy");
        //response.Headers.Should().ContainKey("Permissions-Policy");
        response.Headers.Should().ContainKey("X-Frame-Options");
        //response.Headers.Should().ContainKey("X-XSS-Protection");
        //response.Headers.Should().ContainKey("X-Content-Type-Options");

        //ValidateHeader(response.Headers, "X-Frame-Options", "Deny");
        //ValidateHeader(response.Headers, "X-Content-Type-Options", "nosniff");
        //ValidateHeader(response.Headers, "Referrer-Policy", "no-referrer");
    }

    private static void ValidateHeader(HttpResponseHeaders headers, string name, string value)
    {
        headers.Should().ContainKey(name);

        //headers.Single(h => h.Key == "X-Frame-Options").Should().Be("Deny");
        var header = headers.Single(h => h.Key == name);
        header.Value.Should().Contain(value);
        headers.Single(h => h.Key == name).Value.Should().Contain(value);
    }
}