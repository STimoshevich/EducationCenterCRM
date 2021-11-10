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
    public class TopicsRepository : AbstractRepository<Topic>
    {
        public TopicsRepository(EducationCenterDatabase context) : base(context)
        {
        }


        public async Task<IEnumerable<string>> GetAllTitles()
        {
            return await table.Select(x => x.Title)?.ToListAsync();
        }
    }
}
