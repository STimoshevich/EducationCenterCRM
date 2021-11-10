using EducationCenterCRM.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface IStudingRequestService
    {
        Task<bool> AddNewAsync(int courseId);

        Task<StudingRequestsListDTO> GetAllOpenAsync(int page, int itemsPerPage);
        Task<StudingRequestsListDTO> GetAllClosedAsync(int page, int itemsPerPage);
        IEnumerable<string> GetAllStydingTypes();
        Task ConfirmRequestAsync(int requestId, int groupId);
    }
}
