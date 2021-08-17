using EducationCenterCRM.Services.Interfaces.BLL;
using System.Threading.Tasks;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using System.Collections.Generic;
using AutoMapper;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using System;

namespace EducationCenterCRM.Services.BLL
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public StudentService(IRepository<Student> studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task<List<StudentResponse>> GetAllAsync()
        {
            var allGroups = await studentRepository.GetAllAsync();
            return mapper.Map<List<StudentResponse>>(allGroups);
        }

        public async Task<bool> AddNewAsync(StudentRequest studentRequest)
        {
            //TODO: падает здесь
            var added = 0;
            if (studentRequest is not null)
            {
                var newStudent = mapper.Map<Student>(studentRequest);
                added = await studentRepository.AddAsync(newStudent);
            }
            return added > 0 ? true: false ;
        }

        public async Task<bool> UpdateAsync(int id,StudentRequest studentRequest)
        {
            var updated = 0;
            if (studentRequest is not null)
{
                var student = mapper.Map<Student>(studentRequest);
                student.Id = id;
                updated = await studentRepository.UpdateAsync(student);
            }
            return updated > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await studentRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }
        public async Task<StudentResponse> GetByIdAsync(int id)
        {
            var student = await studentRepository.GetByPredicateOrDefaulAsync(predicate: x => x.Id == id);
            return mapper.Map<StudentResponse>(student);
        }

   
    }
}
