using AutoMapper;
using EducationCenterCRM.BLL.Installers;
using EducationCenterCRM.PresentationLayer.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationCenterCRM.WebApi.ServiceInstallers
{
    public class MaperInstaller : IInstaller
    {
        public void InstallServiecs(IConfiguration configuration, IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
