using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Interfaces
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> table;

        public AbstractRepository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public virtual void Add(T new_value)
        {
            if (new_value is not null)
                table.Add(new_value);
        }

     

        public virtual void Delete(T model)
        {
            if(model is not null)
                table.Remove(model);
        }
      

        public virtual IEnumerable<T> GetAll()
        {
            return table.AsNoTracking();
        }

        public abstract T GetByPredicateOrDefault(Func<T, bool> predicate, bool includeRelations);

        public abstract void Update(T model);
    }

}



       
