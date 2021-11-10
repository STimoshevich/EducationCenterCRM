using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<EducationCenterUser> GetCurrentUserAsync();
        Task<AuthentificationResult> RegisterAsync(UserRegistrationRequest registrationRequest);
        Task<AuthentificationResult> LoginAsync(string email, string password);
        Task<AuthentificationResult> RefreshTokenAsync(RefreshTokenRequest tokens);
        Task LogoutAsync();
        Task<UserListDTO> GetAllAsync();
        Task<IEnumerable<RoleNameWithId>> GetAllRolesNamesWithIdAsync();
        Task ChangeRoles(string newRole, string userId);
    }
}
