using EducationCenterCRM.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthentificationResult> RegisterAsync(string email, string password);
        Task<AuthentificationResult> LoginAsync(string email, string password);
        Task<AuthentificationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
