using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class StudentsRepository : AbstractRepository<Student>
    {
        public StudentsRepository(DbContext context) : base(context)
        {

        }


        public override Student GetByPredicateOrDefault(Func<Student, bool> predicate, bool includeRelations)
        {
            if (predicate is not null)
            {
                var res = includeRelations ?
               context.Set<Student>()
               .Include(x => x.Group)
               .FirstOrDefault(predicate) : context.Set<Student>().FirstOrDefault(predicate);

                return res;
            }

            return default;
        }

        public override void Update(Student model)
        {
            if (model is not null)
            {
                var res = table.FirstOrDefault(x=>x.Id == model.Id);
                if (res is not null)
                {
                    context.Entry(res).CurrentValues.SetValues(model);
                }

            }
        }
    }
}
