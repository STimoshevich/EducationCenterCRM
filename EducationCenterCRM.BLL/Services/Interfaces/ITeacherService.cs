using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface ITeacherService
    {
        void AddNew(Teacher teacher);
        void DeleteById(int id);
        IEnumerable<Teacher> GetAll();
        Teacher GetByIdOrDefault(int id, bool includeRelations);
        void Update(Teacher editedTeacher);
    }
}