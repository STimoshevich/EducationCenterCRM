using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherResponse>> GetAllAsync();
        Task<bool> AddNewAsync(TeacherRequest teacherRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<TeacherResponse> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, TeacherRequest teacherRequest);
    }
}
