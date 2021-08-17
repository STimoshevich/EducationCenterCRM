using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Controllers.V1
{
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
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

        [HttpGet(ApiRoutes.Groups.Get)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await groupService.GetByIdAsync(id));
        }

        [HttpDelete(ApiRoutes.Groups.Delete)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deleted = await groupService.DeleteByIdAsync(id);
            return deleted? NoContent() : NotFound();
        }

        [HttpPost(ApiRoutes.Groups.Create)]
        public async Task<IActionResult> CreateNew([FromBody]GroupRequest groupRequest)
        {
            var created = await groupService.AddNewAsync(groupRequest);
            return created? Ok() : BadRequest(new { error = "Unable to create group" });
        }
        [HttpPut(ApiRoutes.Groups.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id,[FromBody] GroupRequest groupRequest)
        {
            var updated = await groupService.UpdateAsync(Id,groupRequest);
            return updated ? Ok() : NotFound();
        }
    }
}
