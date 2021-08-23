using EducationCenterCRM.BLL.Contracts.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host =  CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var rolemanager = serviceScope
                    .ServiceProvider
                    .GetService<RoleManager<IdentityRole>>();


                if(!await rolemanager.RoleExistsAsync(ApplicationRolles.Admin))
                {
                    var admin = new IdentityRole(ApplicationRolles.Admin);
                    await rolemanager.CreateAsync(admin);
                }
                if (!await rolemanager.RoleExistsAsync(ApplicationRolles.Manager))
                {
                    var manager = new IdentityRole(ApplicationRolles.Manager);
                    await rolemanager.CreateAsync(manager);
                }
               
            }

         


           await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
