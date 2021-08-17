using EducationCenterCRM.BLL.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.ServiceInstallers
{
    public class ApiInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllers();


            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);

            services.AddSingleton(jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true, // валидация ключа безопасности
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)), // установка ключа безопасности
                ValidateIssuer = false,  // укзывает, будет ли валидироваться издатель при валидации токена
                ValidateAudience = false, // будет ли валидироваться потребитель токена
                RequireExpirationTime = false,
                ValidateLifetime = true // будет ли валидироваться время существования
            };


            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = tokenValidationParameters;
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationCenterCRM.WebApi", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Jwt Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
        }
    }
}
