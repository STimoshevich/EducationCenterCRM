﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Entities
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public Topic Parent { get; set; }
    }
}
