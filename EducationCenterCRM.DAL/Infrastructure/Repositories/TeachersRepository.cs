using EducationCenterCRM.DAL.Context;
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
        public TeachersRepository(EducationCenterDatabase context) : base(context)
        {
        }

        public async Task<IEnumerable<Tuple<int, string>>> AllNamesWithId()
        {
            return await table
                .Include(x=>x.EducationCenterUser)
                .Select(x => new Tuple<int, string>(x.Id, $"{x.EducationCenterUser.UserName} {x.EducationCenterUser.PersonLastName}")).ToListAsync();
        }



    }
}
