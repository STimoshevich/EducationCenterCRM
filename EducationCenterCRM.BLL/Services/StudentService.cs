using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.BLL
{
    public class StudentService : IStudentService
    {
        private readonly StudentsRepository studentRepository;
        private readonly UserManager<EducationCenterUser> userManager;
        private readonly IMapper mapper;

        public StudentService(StudentsRepository studentRepository,
            UserManager<EducationCenterUser> userManager,
            IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<List<StudentDTO>> GetAllAsync()
        {
            var allStudents = await studentRepository.GetAllAsync();
            return mapper.Map<List<StudentDTO>>(allStudents);
        }

        public async Task<bool> AddNewAsync(string userId)
        {

            var added = 0;
            if (!string.IsNullOrEmpty(userId))
            {

                var newStudent = new Student()
                {
                    EducationCenterUserId = userId,
                };


                added = await studentRepository.AddAsync(newStudent);


            }
            return added > 0 ? true : false;

        }
        public async Task<bool> UpdateAsync(int id, StudentDTO studentRequest)
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
        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await studentRepository.GetByPredicateOrDefaulAsync(predicate: x => x.Id == id, IsTracking: false);
            return mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> GetByUserIdAsync(string id)
        {

            var user = await userManager.FindByIdAsync(id);
            if (user is not null)
            {
                var student = await studentRepository.GetByPredicateOrDefaulAsync(x => x.EducationCenterUserId == id, IsTracking: false, include: x=>x.Include(x=>x.EducationCenterUser));
                if (student is not null)
                {
                    var result = mapper.Map<StudentDTO>(student);
                    //result.Email = user.Email;
                    //result.Phone = user.PhoneNumber;
                    //result.Lastname = user.PersonLastName;
                    //result.Name = user.PersonName;
                    return result;
                }

            }
            return null;
        }

        public async Task DeleteByUserIdAsync(string Id)
        {
            var stundent = await studentRepository.GetByPredicateOrDefaulAsync(x=>x.EducationCenterUserId == Id, IsTracking: false);
            if (stundent is not null)
            {
                await studentRepository.DeleteAsync(stundent.Id);
            }
        }

    }
}
