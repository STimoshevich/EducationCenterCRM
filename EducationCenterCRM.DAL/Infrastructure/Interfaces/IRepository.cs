using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        void Add(T new_value);
        void Delete(T Model);
        void Update(T model);

        T GetByPredicateOrDefault(Func<T, bool> predicate, bool includeRelations);



    }
}
