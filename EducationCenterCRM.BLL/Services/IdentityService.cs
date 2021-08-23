using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Options;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly EducationCenterDatabase dataContext;
        private readonly IdentitySettings identitySettings;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public IdentityService
            (UserManager<IdentityUser> userManager, JwtSettings jwtSettings,
            TokenValidationParameters tokenValidationParameters, EducationCenterDatabase dataContext,
            IdentitySettings identitySettings, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.tokenValidationParameters = tokenValidationParameters;
            this.dataContext = dataContext;
            this.identitySettings = identitySettings;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<AuthentificationResult> LoginAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return new AuthentificationResult()
                {
                    Success = false,
                    Errors = new[] { "user does not  exist" }
                };

            var userHasValidPassword = await userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
                return new AuthentificationResult()
                {
                    Success = false,
                    Errors = new[] { "user  or password is wrong" }
                };

            await CompareAndSetRolesByAppSettings(user);


            return await GenerateAuthentificationResultForUserAsync(user);
        }

        public async Task<AuthentificationResult> RegisterAsync(string email, string password)
        {
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser is not null)
            {
                return new AuthentificationResult()
                {
                    Success = false,
                    Errors = new[] { "user with this  email already exist" }
                };
            }

            var newUserId = Guid.NewGuid();

            var newUser = new IdentityUser
            {
                Id = newUserId.ToString(),
                Email = email,
                UserName = email
            };



            var createdUser = await userManager.CreateAsync(newUser, password);

           

            if (createdUser.Succeeded)
            {
                await CompareAndSetRolesByAppSettings(newUser);
            }


            if (!createdUser.Succeeded)
                return new AuthentificationResult()
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };

            return await GenerateAuthentificationResultForUserAsync(newUser);
        }

        public async Task<AuthentificationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var claimsPrincipal = GetPrincipalFromToken(token);
            if (claimsPrincipal is null)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "Invalid token " }
                };
            }

            var expiryDateUnix = long.Parse(claimsPrincipal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);


            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token hasn't expired yet" }
                };
            }

            var jti = claimsPrincipal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = dataContext.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken);


            if (storedRefreshToken is null)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token does not exist" }
                };
            }
            if (DateTime.UtcNow > storedRefreshToken.ExpireDate)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token has expired" }
                };
            }
            if (storedRefreshToken.Invalidated)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token has been invalideted" }
                };
            }
            if (storedRefreshToken.Used)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token has been used" }
                };
            }
            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthentificationResult()
                {
                    Errors = new[] { "This token has does not match this JWT" }
                };
            }



            storedRefreshToken.Used = true;
            dataContext.RefreshTokens.Update(storedRefreshToken);
            await dataContext.SaveChangesAsync();


            var user = await userManager.FindByIdAsync(claimsPrincipal.Claims.Single(x => x.Type == "id").Value);

            await CompareAndSetRolesByAppSettings(user);

            return await GenerateAuthentificationResultForUserAsync(user);


        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        private async Task CompareAndSetRolesByAppSettings(IdentityUser user)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            if (!userRoles.Any())
               await userManager.AddToRoleAsync(user, ApplicationRoles.User);

            List<string> adminEmails = identitySettings.Get().AdminEmails;
            List<string> managerEmails = identitySettings.Get().ManagerEmails;

            await CompareAndAddRolesAsync(adminEmails, ApplicationRoles.Admin);
            await CompareAndRemoveRolesAsync(adminEmails,ApplicationRoles.Admin);


            await CompareAndAddRolesAsync(managerEmails, ApplicationRoles.Manager);
            await CompareAndRemoveRolesAsync(managerEmails,ApplicationRoles.Manager);


            async Task CompareAndRemoveRolesAsync(List<string> appSettingsIdentityEmails, string role)
            {
                if (userRoles.FirstOrDefault(x => x == role) is not null
               && !appSettingsIdentityEmails.Contains(user.Email))
                    await userManager.RemoveFromRoleAsync(user, role);
            }
         

            async Task CompareAndAddRolesAsync(List<string> appSettingsIdentityEmails, string role)
            {
                if (appSettingsIdentityEmails.Contains(user.Email)
                 && userRoles.FirstOrDefault(x => x == role) is null)
                    await userManager.AddToRoleAsync(user, role);

            }
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenhandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }
                return principal;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task<AuthentificationResult> GenerateAuthentificationResultForUserAsync(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var claims = new List<Claim>
             {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("id", user.Id)
             };

            var userClaims = await userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(jwtSettings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var resfreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMonths(6)
            };

            await dataContext.RefreshTokens.AddAsync(resfreshToken);
            await dataContext.SaveChangesAsync();

            return new AuthentificationResult()
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = resfreshToken.Token
            };
        }

       
    }
}
