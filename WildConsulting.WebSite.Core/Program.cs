using WildConsulting.WebSite.Core.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
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
        context.Response.Headers.Add("Feature-Policy", SecurityPolicies.FeaturesList);
        context.Response.Headers.Add("Permissions-Policy", SecurityPolicies.PermissionsList);
        await next.Invoke();
    });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
