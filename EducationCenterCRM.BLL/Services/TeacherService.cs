using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure;
using EducationCenterCRM.Services.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.BLL
{
    public class TeacherService : ITeacherService
    {
        private readonly UnitOfWork unitOfWork;

        public TeacherService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return unitOfWork.teachersRepository.GetAll();
        }

        public Teacher GetByIdOrDefault(int id, bool includeRelations)
        {
            return unitOfWork.teachersRepository.GetByPredicateOrDefault(teacher => teacher.Id == id, includeRelations);
        }

        public void DeleteById(int id)
        {
            if (id > 0)
            {
                var teacher = unitOfWork.teachersRepository.GetByPredicateOrDefault(x => x.Id == id, includeRelations: false);
                if (teacher is not null)
                {
                    unitOfWork.teachersRepository.Delete(teacher);
                    unitOfWork.Save();
                }

            }
        }
        public void AddNew(Teacher teacher)
        {
            unitOfWork.teachersRepository.Add(teacher);
            unitOfWork.Save();
        }

        public void Update(Teacher editedTeacher)
        {
            unitOfWork.teachersRepository.Update(editedTeacher);
            unitOfWork.Save();



        }
    }
}
