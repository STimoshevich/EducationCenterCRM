using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EducationCenterCRM.DAL.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class GroupsRepository : AbstractRepository<Group>
    {
        public GroupsRepository(EducationCenterDatabase context) : base(context)
        {
        }

        
    }
}
