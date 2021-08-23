using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseResponse>> GetAllAsync();
        Task<bool> AddNewAsync(CourseRequest groupRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<CourseResponse> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CourseRequest groupRequest);
    }
}
