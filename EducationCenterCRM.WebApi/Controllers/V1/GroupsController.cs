using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Controllers.V1
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupsController : Controller
    {
        private readonly IGroupService groupService;

            
        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

      
        [HttpGet(ApiRoutes.Groups.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await groupService.GetAllAsync());
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpGet(ApiRoutes.Groups.Get)]
        public async Task<IActionResult> GetById(int id)
        {
   
            
            try
            {
                var result = await groupService.GetByIdAsync(id);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpDelete(ApiRoutes.Groups.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            try
            {
                var deleted = await groupService.DeleteByIdAsync(id);
                return deleted ? Ok() : NotFound();
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

          
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPost(ApiRoutes.Groups.Create)]
        public async Task<IActionResult> CreateNew([FromBody]GroupRequest groupRequest)
        {
            try
            {
                var created = await groupService.AddNewAsync(groupRequest);
                return created ? Ok() : BadRequest(new { error = "Unable to create group" });
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }
        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPut(ApiRoutes.Groups.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id,[FromBody] GroupRequest groupRequest)
        {
            try
            {
                var updated = await groupService.UpdateAsync(Id, groupRequest);
                return updated ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }
    }
}
