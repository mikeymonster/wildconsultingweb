using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace WildConsulting.WebSite.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllersWithViews();

            if (Env.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
            else
            {
                services.AddHsts(options =>
                {
                    options.MaxAge = TimeSpan.FromDays(365);
                    options.IncludeSubDomains = true;
                    options.Preload = true;
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
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
                    context.Response.Headers.Add("Feature-Policy", FeaturesList);
                    context.Response.Headers.Add("Permissions-Policy", PermissionsList);
                    await next.Invoke();
                });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // ReSharper disable StringLiteralTypo
        private static StringValues FeaturesList => new StringValues(
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

        private static StringValues PermissionsList => new StringValues(
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
        // ReSharper restore StringLiteralTypo
    }
}
