using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllAsync();
        Task<bool> AddNewAsync(string userId);
        Task<bool> DeleteByIdAsync(int id);
        Task<StudentDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, StudentDTO studentRequest);

        Task<StudentDTO> GetByUserIdAsync(string id);
        Task DeleteByUserIdAsync(string id);
    }
}