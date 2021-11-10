using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class RepositoryRegistrationExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<StudentsRepository>();
            services.AddScoped<GroupsRepository>();
            services.AddScoped<CoursesRepository>();
            services.AddScoped<TopicsRepository>();
            services.AddScoped<TeachersRepository>();
            services.AddScoped<StudingRequestRepository>();
        }
    }
}
