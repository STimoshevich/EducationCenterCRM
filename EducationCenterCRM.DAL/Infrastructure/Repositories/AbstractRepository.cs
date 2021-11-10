using EducationCenterCRM.DAL.Filteres;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public abstract class AbstractRepository<T> where T : class
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




        public virtual async Task<List<T>> GetAllAsync(
          int currentPage = 1, int itemsPerPage = 1000,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool IsTracking = true)
        {
            int skipAmout = (--currentPage) * itemsPerPage;


            if (include is not null)
            {
                return IsTracking
                    ? await include(table).Skip(skipAmout).Take(itemsPerPage).ToListAsync()
                    : await include(table).AsNoTracking().Skip(skipAmout).Take(itemsPerPage).ToListAsync();
            }

            return IsTracking
                   ? (await table.Skip(skipAmout).Take(itemsPerPage).ToListAsync())
                   : (await table.AsNoTracking().Skip(skipAmout).Take(itemsPerPage).ToListAsync());

        }

        public virtual async Task<List<T>> FindAsync(
         Expression<Func<T, bool>> predicate,
        int currentPage = 1, int itemsPerPage = 1000,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool IsTracking = true)
        {
            int skipAmout = (--currentPage) * itemsPerPage;


            if (include is not null)
            {
                return IsTracking
                    ? await include(table).Where(predicate).Skip(skipAmout).Take(itemsPerPage).ToListAsync()
                    : await include(table).Where(predicate).AsNoTracking().Skip(skipAmout).Take(itemsPerPage).ToListAsync();
            }

            return IsTracking
                   ? (await table.Where(predicate).Skip(skipAmout).Take(itemsPerPage).ToListAsync())
                   : (await table.Where(predicate).AsNoTracking().Skip(skipAmout).Take(itemsPerPage).ToListAsync());

        }








        public async Task<(IEnumerable<T> List, int ItemsAmount)> FilterAsync(
            IFilter<T> filter,
            int currentPage = 1, int itemsPerPage = 1000)
        {
            int skipAmout = (--currentPage) * itemsPerPage;

            var specifications = filter.GetSpecifications();

            if (!specifications.Any())
            {
                return (null, 0);
            }


            var expression = PredicateBuilder.New<T>();

            foreach (var specification in specifications)
            {
                expression = expression.And(specification.ApplyFilter());
            }

            var include = filter.GetIncludes();

            List<T> list = include is not null
                ? await include(table).Where(expression).Skip(skipAmout).Take(itemsPerPage).ToListAsync()
                : await table.Where(expression).Skip(skipAmout).Take(itemsPerPage).AsNoTracking().ToListAsync();
         
            var count = await table.AsNoTracking().CountAsync(expression);
            return (list, count);

        }


        public virtual async Task<T> GetByPredicateOrDefaulAsync(
          Expression<Func<T, bool>> predicate,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool IsTracking = true)
        {
            if (predicate is not null)
            {
                if (include is not null)
                {
                    return IsTracking
                        ? (await include(table).FirstOrDefaultAsync(predicate))
                        : (await include(table).AsNoTracking().FirstOrDefaultAsync(predicate));
                }

                return IsTracking
                       ? (await table.FirstOrDefaultAsync(predicate))
                       : (await table.AsNoTracking().FirstOrDefaultAsync(predicate));
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


        public async Task<int> CountAsync(
         Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
         )
        {
            if (include is not null)
                return await include(table).CountAsync(predicate);
            if (predicate is not null)
                return await table.CountAsync(predicate);

            return await table.CountAsync();


        }

    }
}




