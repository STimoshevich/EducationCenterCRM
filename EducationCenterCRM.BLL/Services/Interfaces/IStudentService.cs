using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetAllAsync();
        Task<bool> AddNewAsync(StudentRequest studentRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<StudentResponse> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id,StudentRequest studentRequest);
    }
}