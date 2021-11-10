using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Filterters.TeacherFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherListDTO> GetAllAsync(int currentPage, int itemsPerPage);
         Task<bool> AddNewAsync(string userId);
        Task<bool> DeleteByIdAsync(int id);
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync( TeacherDTO teacherRequest);
        Task<IEnumerable<TeacherNameWithIdDTO>> GetAllNamesWithIdAsync();
        Task<bool> UpdateTeacherCoursesAsync(int teacherId, List<int> newCoursesid);
        Task<TeacherListDTO> GetByFilter(TeacherFilter filter, int currentPage, int itemsPerPage);
        Task DeleteByUserIdAsync(string Id);
    }
}
