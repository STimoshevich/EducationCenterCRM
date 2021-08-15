using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;

        public static class Groups
        {
            public const string GetAll = Base + "/groups";
            public const string Create = Base + "/groups";
            public const string Update = Base + "/groups";
            public const string Get = Base + "/groups/{id}";
            public const string Delete = Base + "/groups/{id}";

        }

        public static class Students
        {
            public const string GetAll = Base + "/students";
            public const string Create = Base + "/students";
            public const string Update = Base + "/students";
            public const string Get = Base + "/students/{id}";
            public const string Delete = Base + "/students/{id}";
        }

        public static class Identity
        {
            public const string Register = Base + "/registration";
            public const string Login = Base + "/login";
            public const string Refresh = Base + "/refreshToken";
        }



    }
}
