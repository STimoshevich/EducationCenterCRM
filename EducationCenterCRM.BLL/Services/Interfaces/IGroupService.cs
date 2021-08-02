using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IGroupService
    {
        void AddNew(Group group);
        void DeleteById(int id);
        IEnumerable<Group> GetAll();
        Group GetByIdOrDefault(int id, bool includeRelations);
        void Update(Group editedGroup);
    }
}