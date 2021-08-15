using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Controllers.V1
{
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
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            return Ok(await groupService.GetByIdAsync(Id));
        }

        [HttpDelete(ApiRoutes.Groups.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int Id)
        {
            var deleted = await groupService.DeleteByIdAsync(Id);
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
