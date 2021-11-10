using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class DbContextRegistrationExtension
    {
        public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<EducationCenterDatabase>(options => options.UseInMemoryDatabase("tmp_database"));
            services.AddDbContext<EducationCenterDatabase>(options =>
            options.UseSqlServer(@"Server=VMSRV2016;Database=EducationCenter;User Id=sa;Password=1234_QWER"));
            services.AddDefaultIdentity<EducationCenterUser>(opt =>
            {
                opt.Password = new PasswordOptions()
                {
                    RequireDigit = false,
                    RequiredLength = 0,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
                };
                opt.User = new UserOptions()
                {
                    AllowedUserNameCharacters = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_@.-"
                };
            }
            )
                .AddRoles<EducationCenterRole>()
                .AddEntityFrameworkStores<EducationCenterDatabase>();

           
        }
    }
}
