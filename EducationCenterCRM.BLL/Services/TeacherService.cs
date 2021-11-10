using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Filterters.TeacherFilters;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TeachersRepository teacherRepository;
        private readonly IMapper mapper;
        private readonly CoursesRepository courseRepository;


        public TeacherService(TeachersRepository teacherRepository, IMapper mapper, CoursesRepository courseRepository)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
            this.courseRepository = courseRepository;


        }

        public async Task<TeacherListDTO> GetAllAsync(int currentPage, int itemsPerPage)
        {
            var result = new TeacherListDTO();
            var allTeachers = await teacherRepository.GetAllAsync(currentPage: currentPage, itemsPerPage: itemsPerPage, include: x => x.Include(x => x.EducationCenterUser));
            var count = await teacherRepository.CountAsync();
            result.Teachers = mapper.Map<List<TeacherDTO>>(allTeachers);
            result.TeachersAmount = count;
            return result;
        }

        public async Task<bool> AddNewAsync(TeacherDTO teacherRequest)
        {
            var added = 0;
            if (teacherRequest is not null)
            {
                var newStudent = mapper.Map<Teacher>(teacherRequest);
                added = await teacherRepository.AddAsync(newStudent);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> AddNewAsync(string userId)
        {

            var added = 0;
            if (!string.IsNullOrEmpty(userId))
            {

                var newTeacher = new Teacher()
                {
                    EducationCenterUserId = userId,
                };


                added = await teacherRepository.AddAsync(newTeacher);


            }
            return added > 0 ? true : false;

        }

        public async Task<bool> UpdateAsync(TeacherDTO teacherRequest)
        {
            var updated = 0;
            if (teacherRequest is not null)
            {
                var teacher = mapper.Map<Teacher>(teacherRequest);
                updated = await teacherRepository.UpdateAsync(teacher);
            }
            return updated > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await teacherRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }
        public async Task<TeacherDTO> GetByIdAsync(int id)
        {
            var student = await teacherRepository.GetByPredicateOrDefaulAsync(predicate: x => x.Id == id, include: x => x.Include(x => x.Courses).Include(x=>x.EducationCenterUser), IsTracking: false);
            return mapper.Map<TeacherDTO>(student);
        }


        public async Task<IEnumerable<TeacherNameWithIdDTO>> GetAllNamesWithIdAsync()
        {
            var repositoryResult = await teacherRepository.AllNamesWithId();
            return repositoryResult?.Select(x => new TeacherNameWithIdDTO { Id = x.Item1, Name = x.Item2 });
        }

        public async Task<bool> UpdateTeacherCoursesAsync(int teacherid, List<int> newCoursesId)
        {
            var updated = 0;
            if (newCoursesId is not null)
            {
                var teacher = await teacherRepository.GetByPredicateOrDefaulAsync(include: x => x.Include(x => x.Courses), predicate: x => x.Id == teacherid) ;

                var coursesForAdd = (await courseRepository
                    .FindAsync(predicate: x => 
                    newCoursesId.Contains(x.Id) && !teacher.Courses.Select(x => x.Id).Contains(x.Id), currentPage: 1, itemsPerPage:int.MaxValue, IsTracking: false));
                teacher.Courses.AddRange(coursesForAdd);

                var coursesForRemove = teacher.Courses.Select(x => x.Id).Where(x => !newCoursesId.Contains(x));
                teacher.Courses.RemoveAll(x => coursesForRemove.Contains(x.Id));

                updated = await teacherRepository.UpdateAsync(teacher);
            }
            return updated > 0 ? true : false;
        }

        public async Task<TeacherListDTO> GetByFilter(TeacherFilter filter, int currentPage, int itemsPerPage)
        {
            var result = new TeacherListDTO();
            var filteredTeachers = await teacherRepository.FilterAsync(filter, currentPage, itemsPerPage);
            if (filteredTeachers.List is not null)
            {
                result.Teachers = mapper.Map<List<TeacherDTO>>(filteredTeachers.List);
                result.TeachersAmount = filteredTeachers.ItemsAmount;
                return result;
            }



            return await GetAllAsync(currentPage, itemsPerPage);
        }

        public async Task DeleteByUserIdAsync(string Id)
        {
            var teacher = await teacherRepository.GetByPredicateOrDefaulAsync(x => x.EducationCenterUserId == Id, IsTracking: false);
            if (teacher is not null)
            {
                await teacherRepository.DeleteAsync(teacher.Id);
            }
        }
    }
}
