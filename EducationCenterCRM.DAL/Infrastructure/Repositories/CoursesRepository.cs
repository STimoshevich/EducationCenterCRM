using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class CoursesRepository : AbstractRepository<Course>
    {
        public CoursesRepository(EducationCenterDatabase context) : base(context)
        {
        }
    }
}
