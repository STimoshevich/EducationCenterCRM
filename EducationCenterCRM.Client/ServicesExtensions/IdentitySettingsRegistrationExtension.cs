using EducationCenterCRM.BLL.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class IdentitySettingsRegistrationExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IdentitySettings>();

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);

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
        }
    }
}
