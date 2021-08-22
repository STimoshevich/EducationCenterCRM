using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace EducationCenterCRM.BLL.Options
{
    public class IdentitySettings
    {
        private readonly IConfiguration configuration;
        private IdentitySettingsValues values = null;

        public IdentitySettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IdentitySettingsValues Get()
        {
           if(values is null)
            {

                values = new IdentitySettingsValues();
                configuration.Bind(nameof(IdentitySettings), values);
            }
               
            return values;
        }



        public class IdentitySettingsValues
        {
           
            public List<string> AdminsEmails { get; set; } = new List<string>();
            public List<string> ManagersEmails { get; set; } = new List<string>();
        }
    }

    
}
