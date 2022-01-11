using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using WildConsulting.WebSite.Core.Pages;
using Xunit;

namespace WildConsulting.WebSite.Core.Tests;
public class HeaderTests : IClassFixture<WebApplicationFactory<IndexModel>>
{
    private readonly WebApplicationFactory<IndexModel> _fixture;

    public HeaderTests(WebApplicationFactory<IndexModel> factory)
    {
        _fixture = factory;
    }

    [Fact]
    public async Task Get_Default_Page_Returns_Expected_Headers()
    {
        var client = _fixture.CreateClient();

        var response = await client.GetAsync("/");

        response.EnsureSuccessStatusCode();

        response.Content.Headers.ContentType.Should().NotBeNull();
        response.Content.Headers.ContentType!.MediaType.Should().Be(MediaTypeNames.Text.Html);

        response.Headers.Should().ContainKey("Feature-Policy");
        response.Headers.Should().ContainKey("Permissions-Policy");
        response.Headers.Should().ContainKey("X-Frame-Options");
        response.Headers.Should().ContainKey("X-XSS-Protection");
        response.Headers.Should().ContainKey("X-Content-Type-Options");

        ValidateHeader(response.Headers, "X-Frame-Options", "Deny");
        ValidateHeader(response.Headers, "X-Content-Type-Options", "nosniff");
        ValidateHeader(response.Headers, "Referrer-Policy", "no-referrer");
    }

    private static void ValidateHeader(HttpResponseHeaders headers, string name, string value)
    {
        headers.Should().ContainKey(name);

        var h = headers.Single(h => h.Key == name);
        //headers.Single(h => h.Key == "X-Frame-Options").Should().Be("Deny");
        h.Value.Should().Contain(value);
        headers.Single(h => h.Key == name).Value.Should().Contain(value);

    }
}
