using EducationCenterCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface IManagerService
    {
        Task<bool> AddNewAsync(string userId, UserRegistrationRequest registrationRequest);
        Task<bool> DeleteByIdAsync(int id);
    }
}
