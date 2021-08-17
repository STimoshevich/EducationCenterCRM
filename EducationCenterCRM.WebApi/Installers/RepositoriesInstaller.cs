using EducationCenterCRM.BLL.Installers;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.WebApi.Installers
{
    public class RepositoriesInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<Group>, GroupsRepository>();
        }
    }
}
