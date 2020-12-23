using System; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace  Rs_71  
{ 
 
    public class Startup 
    { 
        public Startup(IConfiguration configuration) 
        { 
            Configuration = configuration; 
        }
        public IConfiguration Configuration { get; } 
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.Configure<CookiePolicyOptions>(options => 
            { 
                options.CheckConsentNeeded = context => true; 
                options.MinimumSameSitePolicy = SameSiteMode.None; 
            }); 
            services.AddMemoryCache(); 
            services.AddSession(options => 
            { 
                options.IdleTimeout = TimeSpan.FromSeconds(300); 
                options.Cookie.HttpOnly = true; 
                options.Cookie.IsEssential = true; 
            }); 
            services.AddDistributedMemoryCache(); 
            var naloacl = Configuration["naloacl"]; 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 
            services.AddHttpContextAccessor();   
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            if(String.IsNullOrEmpty(naloacl)){ 
                services.Configure<MvcOptions>(options => 
                { 
                    options.Filters.Add(new RequireHttpsAttribute());
                });
            } 
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        { 
            app.UseDeveloperExceptionPage();  
            app.UseSession(); 
            app.UseStaticFiles(); 
            app.UseCookiePolicy(); 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=user}/{action=login}");
            }); 
            app.UseCookiePolicy();
            app.UseHsts(); 
            app.UseHttpsRedirection(); 
            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(StatusCodes.Status301MovedPermanently, 443));  
        }




    } 
} 
