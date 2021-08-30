using EducationCenterCRM.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class DbContextRegistrationExtension
    {
        public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EducationCenterDatabase>(options => options.UseInMemoryDatabase("tmp_database"));
            //services.AddDbContext<EducationCenterDatabase>(options=>
            //  options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EducationCenter;Trusted_Connection=True;"));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EducationCenterDatabase>();
        }
    }
}
