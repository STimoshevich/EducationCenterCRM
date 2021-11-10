using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Filteres.GroupFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.Interfaces.BLL
{
    public interface IGroupService
    {
        Task<GroupListDTO> GetAllAsync(int page, int itemsPerPage);
        Task<bool> AddNewAsync(GroupDTO groupRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<GroupDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync( GroupDTO groupRequest);
        Task<GroupListDTO> GetByFilter(GroupFilter filter, int currentPage, int itemsPerPage);
        IEnumerable<string> GetAllGroupStatusNames();
        Task<IEnumerable<GroupDTO>> FindGroupsForRequest(int requestId);
        Task<IEnumerable<StudentDTO>> GetStudentsByGroupId(int groupId);
    }
}