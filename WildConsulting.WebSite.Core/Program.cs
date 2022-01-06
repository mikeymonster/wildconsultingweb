using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
// ReSharper disable All

var featuresList = new StringValues(
    "accelerometer 'none';" +
    "autoplay 'none';" +
    "camera 'none';" +
    "document-domain 'none';" +
    "encrypted-media 'none';" +
    "fullscreen 'self';" +
    "geolocation 'none';" +
    "gyroscope 'none';" +
    "magnetometer 'none';" +
    "microphone 'none';" +
    "midi 'none';" +
    "payment 'none';" +
    "picture-in-picture 'none';" +
    "publickey-credentials-get 'none';" +
    "sync-xhr 'none';" +
    "usb 'none';" +
    "xr-spatial-tracking 'none';");

var permissionsList = new StringValues(
    "accelerometer=();" +
    "autoplay=();" +
    "camera=();" +
    "document-domain=();" +
    "encrypted-media=();" +
    "fullscreen=(self);" +
    "geolocation=();" +
    "gyroscope=();" +
    "magnetometer=();" +
    "microphone=();" +
    "midi=();" +
    "payment=();" +
    "picture-in-picture=();" +
    "publickey-credentials-get=();" +
    "speaker=(self);" +
    "sync-xhr=();" +
    "usb=();" +
    "xr-spatial-tracking=();");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts(options =>
    {
        options.MaxAge(365);
        options.IncludeSubdomains();
        options.Preload();
    });
}

app.UseXContentTypeOptions()
    .UseReferrerPolicy(opts => opts.NoReferrer())
    .UseXXssProtection(opts => opts.EnabledWithBlockMode())
    .UseXfo(xfo => xfo.Deny())
    .UseCsp(options => options
        .DefaultSources(s => s.Self())
        .StyleSources(s => s.Self())
        .ScriptSources(s => s.Self())
        .ObjectSources(s => s.None()))
    .Use(async (context, next) =>
    {
        context.Response.Headers.Add("Expect-CT", "max-age=0, enforce"); //Not using report-uri=
        context.Response.Headers.Add("Feature-Policy", featuresList);
        context.Response.Headers.Add("Permissions-Policy", permissionsList);
        await next.Invoke();
    });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
