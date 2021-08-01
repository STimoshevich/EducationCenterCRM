using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class GroupsRepository : AbstractRepository<Group>
    {
        public GroupsRepository(DbContext context) : base(context)
        {
        }
        public override Group GetByPredicateOrDefault(Func<Group, bool> predicate, bool includeRelations)
        {
            if (predicate is not null)
            {
                var res = includeRelations ?
               context.Set<Group>()
               .Include(x => x.Students)
               .Include(x => x.Teacher)
               .FirstOrDefault(predicate) : context.Set<Group>().FirstOrDefault(predicate);

                return res;
            }

            return default;
        }


        public override void Update(Group model)
        {
            if (model is not null)
            {
                var res = table.FirstOrDefault(x => x.Id == model.Id);
                if (res is not null)
                {
                    context.Entry(res).CurrentValues.SetValues(model);
                }

            }
        }
    }
}
