using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class GroupsRepository : AbstractRepository<Group>
    {
        public GroupsRepository(EducationCenterDatabase context) : base(context)
        {
        }

        public async Task  AddStudent(int groupId, Student student)
        {
          var group = await  table.FirstOrDefaultAsync(x => x.Id == groupId);
            if (group is not null && student is not null)
            {
                group.Students.Add(student);
                context.SaveChanges();
            }
        }
      

    }


}

