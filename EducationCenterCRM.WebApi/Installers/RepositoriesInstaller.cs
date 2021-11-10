using EducationCenterCRM.BLL.Installers;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationCenterCRM.WebApi.Installers
{
    public class RepositoriesInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<AbstractRepository<Student>, StudentsRepository>();
            services.AddScoped<AbstractRepository<Group>, GroupsRepository>();
            services.AddScoped<AbstractRepository<Course>, CoursesRepository>();
            services.AddScoped<AbstractRepository<Topic>, TopicsRepository>();
            services.AddScoped<AbstractRepository<Teacher>, TeachersRepository>();
        }
    }
}
