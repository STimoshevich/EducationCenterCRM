using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
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



        public virtual async Task<int> DeleteAsync(int id)
        {
            var deleted = 0;
            if (id > 0)
            {
                var entity = await table.FindAsync(id);
                if (entity is not null)
                {
                    table.Remove(entity);
                    deleted = await context.SaveChangesAsync();
                }
            }
            return deleted;

        }


        public virtual async Task<List<T>> GetAllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }


        public virtual async Task<T> GetByPredicateOrDefaulAsync(
          Expression<Func<T, bool>> predicate,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool IsTracking = false)
        {
            if (predicate is not null)
            {
                if (include is not null)
                {
                    return IsTracking ?
                         (await include(table).FirstOrDefaultAsync(predicate)) :
                         (await include(table).AsNoTracking().FirstOrDefaultAsync(predicate));
                }

                return IsTracking ?
                        (await table.FirstOrDefaultAsync(predicate)) :
                        (await table.AsNoTracking().FirstOrDefaultAsync(predicate));
            }
            return null;
        }

        public virtual async Task<int> UpdateAsync(T model)
        {
            int updated = 0;
            if (model is not null)
            {
                table.Update(model);
                updated = await context.SaveChangesAsync();
            }
            return updated;

        }

    }

}




