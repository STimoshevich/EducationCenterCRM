using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using EducationCenterCRM.DAL.Filteres.CourseFilters;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class CourseService : ICourseService
    {


        private readonly CoursesRepository courseRepository;
        private readonly GroupsRepository groupRepository;
        private readonly IMapper mapper;

        public CourseService(CoursesRepository courseRepository, GroupsRepository groupRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }


        public async Task<CourseListDTO> GetAllAsync(int page, int itemsPerPage)
        {
            var result = new CourseListDTO();
            var allCourses = await courseRepository.GetAllAsync(include: course => course.Include(x => x.Topic), currentPage: page, itemsPerPage: itemsPerPage);
            result.Courses = mapper.Map<List<CourseDTO>>(allCourses);
            result.CoursesAmount = await courseRepository.CountAsync();
            return result;
        }


        public async Task<bool> AddNewAsync(CourseDTO courseRequest)
        {
            var added = 0;
            if (courseRequest is not null)
            {
                var course = mapper.Map<Course>(courseRequest);
                added = await courseRepository.AddAsync(course);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await courseRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }




        public async Task<bool> UpdateAsync(CourseDTO courseRequest)
        {
            var updated = 0;
            if (courseRequest is not null)
            {
                var newCourse = mapper.Map<Course>(courseRequest);
                updated = await courseRepository.UpdateAsync(newCourse);
            }
            return updated > 0 ? true : false;
        }


        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var res = await courseRepository.GetByPredicateOrDefaulAsync
                (predicate: x => x.Id == id,
                IsTracking: false);
            return mapper.Map<CourseDTO>(res);
        }

        public IEnumerable<string> GetAllCourseLvls()
        {
            foreach (var names in Enum.GetNames(typeof(CourseLevel)))
            {
                yield return names;
            }
        }

        public async Task<CourseListDTO> SearchAsync(string searchString, int currentPage, int itemsPerPage)
        {
            var result = new CourseListDTO();
            var searchResult = await courseRepository.SearchAsync(searchString, currentPage, itemsPerPage);
            result.Courses = mapper.Map<List<CourseDTO>>(searchResult.Courses);
            result.CoursesAmount = searchResult.ItemsAmount;
            return result;

        }


        public async Task<CourseListDTO> GetByFilter(CourseFilter filter, int currentPage, int itemsPerPage)
        {

            var result = new CourseListDTO();
            var filteredCourses = await courseRepository.FilterAsync(filter, currentPage, itemsPerPage);
            if (filteredCourses.List is not null)
            {
                result.Courses = mapper.Map<List<CourseDTO>>(filteredCourses.List);
                result.CoursesAmount = filteredCourses.ItemsAmount;
                return result;
            }
            return await GetAllAsync(currentPage, itemsPerPage);

        }



        public async Task<IEnumerable<CourseTItleWithIdDTO>> GetAllTitlesWithId()
        {
            var repositoryResult = await courseRepository.AllTitleWithId();
            return repositoryResult?.Select(x => new CourseTItleWithIdDTO { Id = x.Item1, Title = x.Item2 });
        }

        public async Task<IEnumerable<TeacherNameWithIdDTO>> AllTeachersNamesWithIdbyCourse(int courseId)
        {
            var repositoryResult = await courseRepository.AllTeachersNamesWithIdbyCourse(courseId);
            return repositoryResult?.Select(x => new TeacherNameWithIdDTO { Id = x.Item1, Name = x.Item2 });
        }

    }

}
