using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class RepositoryRegistrationExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, StudentsRepository>();
            services.AddScoped<IRepository<Group>, GroupsRepository>();
            services.AddScoped<IRepository<Course>, CoursesRepository>();
            services.AddScoped<IRepository<Topic>, TopicsRepository>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();
        }
    }
}
