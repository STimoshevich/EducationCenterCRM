﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }    
}
