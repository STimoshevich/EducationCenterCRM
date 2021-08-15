using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> GetAllAsync();
        Task<int> AddAsync(T new_value);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T model);
        Task<T> GetByPredicateOrDefaultAsync(Func<T, bool> predicate);



    }
}
