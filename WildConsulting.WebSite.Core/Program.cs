using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WildConsulting.WebSite.Core;

CreateWebHostBuilder(args).Build().Run();

static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
