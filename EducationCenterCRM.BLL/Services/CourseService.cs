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
    public class CourseService :ICourseService
    {


        private readonly IRepository<Course> courseRepository;
        private readonly IMapper mapper;

        public CourseService(IRepository<Course> courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }


        public async Task<List<CourseResponse>> GetAllAsync()
        {
            var allCourses = await courseRepository.GetAllAsync();
            return mapper.Map<List<CourseResponse>>(allCourses);
        }

        public async Task<bool> AddNewAsync(CourseRequest courseRequest)
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
       

        public  async Task<bool> UpdateAsync(int id, CourseRequest courseRequest)
        {
            var updated = 0;
            if (courseRequest is not null)
            {
                var newCourse = mapper.Map<Course>(courseRequest);
                newCourse.Id = id;
                updated = await courseRepository.UpdateAsync(newCourse);
            }
            return updated > 0 ? true : false;
        }

       
        public  async Task<CourseResponse> GetByIdAsync(int id)
        {
            var topic = await courseRepository.GetByPredicateOrDefaulAsync
                (predicate: x => x.Id == id,
                IsTracking: false);
            return mapper.Map<CourseResponse>(topic);
        }
    }
}
