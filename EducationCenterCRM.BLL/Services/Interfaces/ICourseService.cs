using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Filteres.CourseFilters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseListDTO> GetAllAsync(int page, int itemsPerPage);
        Task<bool> AddNewAsync(CourseDTO groupRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<CourseDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(CourseDTO groupRequest);
        Task<CourseListDTO> GetByFilter(CourseFilter filter, int currentPage, int itemsPerPage);
        IEnumerable<string> GetAllCourseLvls();
        Task<CourseListDTO> SearchAsync(string searchString, int currentPage, int itemsPerPage);
        Task<IEnumerable<CourseTItleWithIdDTO>> GetAllTitlesWithId();
        Task<IEnumerable<TeacherNameWithIdDTO>> AllTeachersNamesWithIdbyCourse(int courseId);
      
    }
}
