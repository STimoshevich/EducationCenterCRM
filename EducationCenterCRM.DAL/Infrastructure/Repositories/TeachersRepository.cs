using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class TeachersRepository : AbstractRepository<Teacher>
    {
        public TeachersRepository(DbContext context) : base(context)
        {
        }


      
    }
}
