using AutoMapper;
using EducationCenterCRM.DAL.Infrastructure;
using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using EducationCenterCRM.Services.Interfaces.BLL;

namespace EducationCenterCRM.Services.BLL
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork unitOfWork;

        public StudentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        public void Update(Student editedStudent)
        {
            unitOfWork.studentsRepository.Update(editedStudent);
            unitOfWork.Save();
        }

        public void AddNew(Student student)
        {
            unitOfWork.studentsRepository.Add(student);
            unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            if (id > 0)
            {
                var result = unitOfWork.studentsRepository.GetByPredicateOrDefault(x => x.Id == id, includeRelations: false);
                if (result is not null)
                {
                    unitOfWork.studentsRepository.Delete(result);

                    unitOfWork.Save();
                }

            }
        }

        public Student GetByIdOrDefault(int id, bool includeRelations)
        {
            return unitOfWork.studentsRepository.GetByPredicateOrDefault(student => student.Id == id, includeRelations);
        }
        public IEnumerable<Student> GetAll()
        {
            return unitOfWork.studentsRepository.GetAll();
        }

    }
}
