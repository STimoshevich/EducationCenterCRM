using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IStudentService
    {
        void AddNew(Student student);
        void DeleteById(int id);
        IEnumerable<Student> GetAll();
        Student GetByIdOrDefault(int id, bool includeRelations);
        void Update(Student editedStudent);
    }
}