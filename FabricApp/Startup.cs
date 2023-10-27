using FabricAPP.Interfaces;
using FabricAPP.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;

namespace FabricAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IAddEmployeesFromXMLViewModel, AddEmployeesFromXMLViewModel>();
            services.AddTransient<IShowEmployeesViewModel, ShowEmployeesViewModel>();
            services.AddTransient<IAddEmployeeViewModel, AddEmployeeViewModel>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["Google:ClientId"];
                options.ClientSecret = Configuration["Google:ClientSecret"];
                options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                options.ClaimActions.MapJsonKey("urn:google:image", "picture");
            });
            //.AddFacebook(options =>
            // {
            //     options.AppId = Configuration["Facebook:AppId"];
            //     options.AppSecret = Configuration["Facebook:AppSecret"];
            //     options.ClaimActions.MapJsonKey("urn:facebook:profile", "link");
            //     options.ClaimActions.MapJsonKey("urn:facebook:image", "picture");
            // })
            //.AddMicrosoftAccount(options =>
            //{
            //    options.ClientId = Configuration["Microsoft:ClientId"];
            //    options.ClientSecret = Configuration["Microsoft:ClientSecret"];
            //    options.ClaimActions.MapJsonKey("urn:microsoft:profile", "link");
            //    options.ClaimActions.MapJsonKey("urn:microsoft:image", "picture");
            //});
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
