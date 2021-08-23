using AutoMapper;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IMapper mapper;

        public TeacherService(IRepository<Teacher> teacherRepository, IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        public async Task<List<TeacherResponse>> GetAllAsync()
        {
            var allTeachers = await teacherRepository.GetAllAsync();
            return mapper.Map<List<TeacherResponse>>(allTeachers);
        }

        public async Task<bool> AddNewAsync(TeacherRequest teacherRequest)
        {
            var added = 0;
            if (teacherRequest is not null)
            {
                var newStudent = mapper.Map<Teacher>(teacherRequest);
                added = await teacherRepository.AddAsync(newStudent);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(int id, TeacherRequest teacherRequest)
        {
            var updated = 0;
            if (teacherRequest is not null)
            {
                var teacher = mapper.Map<Teacher>(teacherRequest);
                teacher.Id = id;
                updated = await teacherRepository.UpdateAsync(teacher);
            }
            return updated > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await teacherRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }
        public async Task<TeacherResponse> GetByIdAsync(int id)
        {
            var student = await teacherRepository.GetByPredicateOrDefaulAsync(predicate: x => x.Id == id);
            return mapper.Map<TeacherResponse>(student);
        }

    }
}
