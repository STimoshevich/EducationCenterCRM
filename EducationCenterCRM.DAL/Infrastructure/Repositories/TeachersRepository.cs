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
    public class TeachersRepository : AbstractRepository<Teacher>
    {
        public TeachersRepository(DbContext context) : base(context)
        {
        }

        public override Teacher GetByPredicateOrDefault(Func<Teacher, bool> predicate, bool includeRelations)
        {
            if (predicate is not null)
            {
                var res = includeRelations ?
               context.Set<Teacher>()
               .Include(x => x.Groups)
               .FirstOrDefault(predicate) : context.Set<Teacher>().FirstOrDefault(predicate);

                return res;
            }

            return default;
        }

        public override void Update(Teacher model)
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
