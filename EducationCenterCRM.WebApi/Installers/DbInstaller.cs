using EducationCenterCRM.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
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
