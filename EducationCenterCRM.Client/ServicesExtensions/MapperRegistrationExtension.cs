using AutoMapper;
using EducationCenterCRM.PresentationLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.ServicesExtensions
{
    public static class MapperRegistrationExtension
    {
        public static void AddMapperConfiguration( this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
