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

namespace EducationCenterCRM.BLL.ServiceInstallers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<EducationCenterDatabase>(options => options.UseInMemoryDatabase("tmp_database"));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<EducationCenterDatabase>();
        }
    }
}
