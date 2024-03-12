using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using eCollege.Data;
using eCollege.Models;
using eCollege.Services;

namespace eCollege
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddCloudscribeNavigation(Configuration.GetSection("NavigationOptions"));
            services.AddMvc()
                        .AddRazorOptions(options =>
                        {
                // if you download the cloudscribe.Web.Navigation Views and put them in your views folder
                // then you don't need this line and can customize the views (recommended)
                // you can find them here:
                // https://github.com/joeaudette/cloudscribe.Web.Navigation/tree/master/src/cloudscribe.Web.Navigation/Views
                options.AddEmbeddedViewsForNavigation();
                        });

            var connection = @"Data Source=GTECH-250G3\SQLEXPRESS;Initial Catalog=UCMS;Integrated Security=True";
         services.AddDbContext<UCMSContext>(options => options.UseSqlServer(connection));

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "employees",
                    template: "{controller=Employees}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "students",
                   template: "{controller=Students}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "timetable",
                   template: "{controller=TimeTable}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "score",
                   template: "{controller=Score}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "fees",
                   template: "{controller=Fees}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "subjects",
                   template: "{controller=Subjects}/{action=Index}/{id?}");
            });
        }
    }
}
