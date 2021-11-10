using EducationCenterCRM.Client.ServicesExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;


namespace EducationCenterCRM.Client
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

            services.AddControllersWithViews().AddNewtonsoftJson(opts =>
            { 
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                var enumConverter = new JsonStringEnumConverter();
                opts.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

          


            services.AddDbContextConfiguration(Configuration);
            services.AddRepositories();
            services.AddBllServices();
            services.AddIdentityConfiguration(Configuration);
            services.AddMapperConfiguration(Configuration);

           
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionMiddleware();

            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
