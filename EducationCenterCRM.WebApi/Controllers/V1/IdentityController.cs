using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using Serilog;

namespace EducationCenterCRM.WebApi.Controllers.V1
{
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
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
                var authResponse = await identityService.RegisterAsync(request.Email, request.Password);
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

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
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
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           

        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
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
                var authResponse = await identityService.RefreshTokenAsync(request.Token, request.RefreshToken);
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
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

           
        }


        [HttpPost(ApiRoutes.Identity.Logout)]
        public async Task<IActionResult> Logout()
        {
            await identityService.LogoutAsync();

            return Ok();


        }
    }
}
