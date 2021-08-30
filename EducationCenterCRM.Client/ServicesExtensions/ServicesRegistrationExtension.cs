using EducationCenterCRM.BLL.Services;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.Services.BLL;
using EducationCenterCRM.Services.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class ServicesRegistrationExtension
    {
        public static void AddServices (this IServiceCollection services)
        {

            //services.AddScoped<IGroupService, GroupService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
            //services.AddScoped<ITopicService, TopicService>();
        }

    }
}
