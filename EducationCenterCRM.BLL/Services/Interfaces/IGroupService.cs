using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IGroupService
    {
        Task<List<GroupResponse>> GetAllAsync();
        Task<bool> AddNewAsync(GroupRequest groupRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<GroupResponse> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, GroupRequest groupRequest);
    }
}