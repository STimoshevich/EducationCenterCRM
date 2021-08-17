using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Installers
{
    public interface IInstaller
    {
        void InstallServiecs(IConfiguration configuration, IServiceCollection services);
    }
}
