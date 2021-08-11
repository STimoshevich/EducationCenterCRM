using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.PL.ApiContracts.V1.Routes
{
    public class ApiRoutes
    {
        public const string Varsion = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Varsion;

        public class Group
        {
            public const string GetAll = Base + "/groups";
            public const string Create = Base + "/groups";
            public const string Update = Base + "/groups";
            public const string Get = Base + "/groups/{id}";
            public const string Delete = Base + "/groups/{id}";

        }

    }
}
