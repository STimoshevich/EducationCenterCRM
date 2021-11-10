using AutoMapper;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Options;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL;
using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<EducationCenterUser> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly EducationCenterDatabase dataContext;
        private readonly IdentitySettings identitySettings;
        private readonly RoleManager<EducationCenterRole> roleManager;
        private readonly SignInManager<EducationCenterUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public IdentityService
            (UserManager<EducationCenterUser> userManager, JwtSettings jwtSettings,
            IStudentService studentService,
            ITeacherService teacherService,
            TokenValidationParameters tokenValidationParameters, EducationCenterDatabase dataContext,
            IdentitySettings identitySettings, RoleManager<EducationCenterRole> roleManager, SignInManager<EducationCenterUser> signInManager,
             IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.tokenValidationParameters = tokenValidationParameters;
            this.dataContext = dataContext;
            this.identitySettings = identitySettings;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }


        public async Task<EducationCenterUser> GetCurrentUserAsync()
        {
            var userClaims = httpContextAccessor.HttpContext?.User;
            var user = await userManager.FindByIdAsync(userClaims.Claims.Single(x => x.Type == "id").Value);

            return user;
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

        public async Task<AuthentificationResult> RegisterAsync(UserRegistrationRequest registrationRequest)
        {
            var existingUser = await userManager.FindByEmailAsync(registrationRequest.Email);
            if (existingUser is not null)
            {
                return new AuthentificationResult()
                {
                    Success = false,
                    Errors = new[] { "user with this  email already exist" }
                };
            }

            var newUserId = Guid.NewGuid();


            var newUser = new EducationCenterUser
            {
                Id = newUserId.ToString(),
                Email = registrationRequest.Email,
                UserName = registrationRequest.Email,
                PersonName = registrationRequest.Name,
                PersonLastName = registrationRequest.LastName,
                PhoneNumber = registrationRequest.Phone,
            };



            var createdUser = await userManager.CreateAsync(newUser, registrationRequest.Password);



            if (!createdUser.Succeeded)
            {
                return new AuthentificationResult()
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            await CompareAndSetRolesByAppSettings(newUser);


            await AddToTableByRole(newUser);

            return await GenerateAuthentificationResultForUserAsync(newUser);
        }

        public async Task<AuthentificationResult> RefreshTokenAsync(RefreshTokenRequest tokens)
        {
            var claimsPrincipal = GetPrincipalFromToken(tokens.Token);
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

            var storedRefreshToken = dataContext.RefreshTokens.SingleOrDefault(x => x.Token == tokens.RefreshToken);



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

        private async Task AddToTableByRole(EducationCenterUser user)
        {
            if (await userManager.IsInRoleAsync(user, ApplicationRoles.Student))
            {
                await studentService.AddNewAsync(user.Id);
            }
            if (await userManager.IsInRoleAsync(user, ApplicationRoles.Teacher))
            {
                await teacherService.AddNewAsync(user.Id);
            }
        }


        private async Task RemoveFromTableByRole(EducationCenterUser user,List<string> roles)
        {

            

            if (roles.Contains(ApplicationRoles.Student))
            {
                await studentService.DeleteByUserIdAsync(user.Id);
            }
            if (roles.Contains(ApplicationRoles.Teacher))
            {
                await teacherService.DeleteByUserIdAsync(user.Id);
            }
        }

        public async Task ChangeRoles(string newRole, string userId)
        {
            if (await roleManager.Roles.FirstOrDefaultAsync(x => x.Name == newRole) is not null)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(x=>x.Id == userId);
                if (!(await userManager.IsInRoleAsync(user, newRole)) && user is not null)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    await RemoveFromTableByRole(user,roles.ToList());

                    await userManager.RemoveFromRolesAsync(user,roles);
                    var result =  await userManager.AddToRoleAsync(user, newRole);

                  

                    await AddToTableByRole(user);

                 
                }
            }

        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        private async Task CompareAndSetRolesByAppSettings(EducationCenterUser user)
        {
            var userRoles = await userManager.GetRolesAsync(user);



            List<string> adminEmails = identitySettings.Get().AdminEmails;
            List<string> managerEmails = identitySettings.Get().ManagerEmails;

            await CompareWirhSettingsAndAddRolesAsync(adminEmails, ApplicationRoles.Admin);
            await CompareWithSettingsAndRemoveRolesAsync(adminEmails, ApplicationRoles.Admin);


            await CompareWirhSettingsAndAddRolesAsync(managerEmails, ApplicationRoles.Manager);
            await CompareWithSettingsAndRemoveRolesAsync(managerEmails, ApplicationRoles.Manager);



            if (!(await userManager.GetRolesAsync(user)).Any())
                await userManager.AddToRoleAsync(user, ApplicationRoles.Student);


            async Task CompareWithSettingsAndRemoveRolesAsync(List<string> appSettingsIdentityEmails, string role)
            {

                if (userRoles.FirstOrDefault(x => x == role) is not null
               && !appSettingsIdentityEmails.Contains(user.Email))
                    await userManager.RemoveFromRoleAsync(user, role);
            }
            async Task CompareWirhSettingsAndAddRolesAsync(List<string> appSettingsIdentityEmails, string role)
            {
                if (appSettingsIdentityEmails.Contains(user.Email)
                 && userRoles.FirstOrDefault(x => x == role) is null)
                {
                    await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
                    await userManager.AddToRoleAsync(user, role);
                }


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

        private async Task<AuthentificationResult> GenerateAuthentificationResultForUserAsync(EducationCenterUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var claims = new List<Claim>
             {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                  new Claim(JwtRegisteredClaimNames.Name, user.UserName),
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

        public async Task<UserListDTO> GetAllAsync()
        {
            var res = new UserListDTO();
           var userInAdminRole = await  userManager.GetUsersInRoleAsync(ApplicationRoles.Admin);
            var users = await userManager
                .Users
                .AsNoTracking()
                .Where(x=> !userInAdminRole.Contains(x))
                .Include(x => x.Person)
                .OrderBy(x=>x.PersonName)
                .ToListAsync();

            res.users = mapper.Map<List<UserDTO>>(users);

            res.users.ForEach(x => x.Roles = userManager.GetRolesAsync(userManager.Users.FirstOrDefault(y => y.Id == x.Id)).Result.ToList());

            res.usersAmount = await userManager.Users.AsNoTracking().CountAsync();

            return res;
        }


        public async Task<IEnumerable<RoleNameWithId>> GetAllRolesNamesWithIdAsync()
        {
            return await roleManager?
                .Roles
                .Where(x => x.Name != ApplicationRoles.Admin)
                .Select(x => new RoleNameWithId { Id = x.Id, Name = x.Name })
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
