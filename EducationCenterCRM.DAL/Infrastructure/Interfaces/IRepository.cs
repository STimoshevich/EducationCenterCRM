using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> GetAllAsync(
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool IsTracking = true);
        Task<int> AddAsync(T new_value);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T model);
        Task<T> GetByPredicateOrDefaulAsync(
          Expression<Func<T, bool>> predicate,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool IsTracking = false);


    }
}
