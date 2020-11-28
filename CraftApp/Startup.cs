using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using CraftApp.Service;
using CraftApp.Data;
using Microsoft.EntityFrameworkCore;
using CraftApp.Data.Repositories;
using CraftApp.Data.Entity;
using Microsoft.AspNetCore.Http;
using CraftApp.Models;

namespace CraftApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CraftDbContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICraftRepository, EFCraftRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IOrderRepository, EFOrder>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(e => EFCart.GetCart(e));


            Configuration.Bind("Project", new Config());

            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddMemoryCache();
            services.AddSession();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "categoryFilter",
                //    pattern: "{controller=Craft}/{action=List}/{category?}");

            });
        }
    }
}
