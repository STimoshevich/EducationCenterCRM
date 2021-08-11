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
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationCenterCRM.WebAPi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

           
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EducationCenterCRM.WebAPi v1");
                    c.RoutePrefix = "apiDocumantations";
                });
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
