using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.WebApi.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {


                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            try
            {
                var authResponse = await identityService.RegisterAsync(request);
                if (!authResponse.Success)
                    return BadRequest(new AuthFailedResponse
                    {
                        Errors = authResponse.Errors
                    }
                );

                return Ok(new AuthSuccessResponse()
                {
                    Token = authResponse.Token,
                    RefreshToken = authResponse.RefreshToken
                });
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }


            var authResponse = await identityService.LoginAsync(request.Email, request.Password);
            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });


            return Ok(new AuthSuccessResponse()
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });

        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponse = await identityService.RefreshTokenAsync(request);
            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });


            return Ok(new AuthSuccessResponse()
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });


        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await identityService.LogoutAsync();
            return Ok();
        }


        [HttpGet("getallusers")]
        public async Task<IActionResult> GetallusersAsync()
        {
            return Ok(await identityService.GetAllAsync());
        }

        [HttpGet("getallroles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await identityService.GetAllRolesNamesWithIdAsync());
        }



        [HttpPut("changeroles")]
        public async Task<IActionResult> ChangerRoles([FromBody] changeRolesDTO model)
        {
            await identityService.ChangeRoles(model.roleName, model.userId);
            return Ok();
        }
    }
   
}
