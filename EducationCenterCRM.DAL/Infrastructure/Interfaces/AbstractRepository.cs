using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public virtual async Task<int> AddAsync(T new_value)
        {
            int added = 0;
            if (new_value is not null)
            {
                await table.AddAsync(new_value);
                added = await context.SaveChangesAsync();
            }
              
            return added;
        }

     

        public virtual async Task<int> DeleteAsync( int id)
        {
            var deleted = 0;
            if(id > 0)
            {
                var entity = await table.FindAsync(id);
                if (entity is not null)
                {
                    table.Remove(entity);
                    deleted = await context.SaveChangesAsync();
                }
                table.Remove(entity);
                 deleted = await context.SaveChangesAsync();
            }
            return deleted;
              
        }
      

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }

        public virtual  async Task<T> GetByPredicateOrDefaultAsync(Func<T, bool> predicate)
        {
            if(predicate is not null)
            {
                return await context.Set<T>().FindAsync(predicate);
            }
            return null;
        }


        public virtual async Task<int> UpdateAsync(T model)
        {
            int updated = 0;
            if(model is not null)
            {
                table.Update(model);
                updated = await context.SaveChangesAsync();
            }
            return updated;
          
        }

    }

}



       
