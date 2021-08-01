using EducationCenterCRM.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using EducationCenterCRM.PresentationLayer.Mapper;
using EducationCenterCRM.Services.BLL;
using EducationCenterCRM.DAL.Infrastructure;

namespace EducationCenterCRM.PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

         
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<StudentService>();
            services.AddScoped<GroupService>();
            services.AddScoped<TeacherService>();

            services.AddDbContext<DbContext,EducationCenterDatabase>(options => options.UseInMemoryDatabase("EducationCenterDatabase"));
           
            services.AddScoped<UnitOfWork>();

            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }

 
}
