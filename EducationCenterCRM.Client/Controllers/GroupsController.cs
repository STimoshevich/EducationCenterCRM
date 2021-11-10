using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Filteres.GroupFilters;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : Controller
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, int itemsPerPage = 4)
        {
            return Ok(await groupService.GetAllAsync(page, itemsPerPage));
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await groupService.GetByIdAsync(id);
            return Ok(res);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            var deleted = await groupService.DeleteByIdAsync(id);
            return deleted ? Ok() : NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNew([FromBody] GroupDTO courseRequest)
        {
            var created = await groupService.AddNewAsync(courseRequest);
            return created ? Ok() : BadRequest(new { error = "Unable to create group" });


        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] GroupDTO groupRequest)
        {
            var updated = await groupService.UpdateAsync(groupRequest);
            return updated ? Ok() : NotFound();
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GroupFilter filter, int page = 1, int itemsPerPage = 4)
        {
            var coursesResult = await groupService.GetByFilter(filter, page, itemsPerPage);
            return Ok(coursesResult);
        }

        [HttpGet("getallstatuses")]
        public IActionResult GetAllGroupStatusNames()
        {
            return Ok(groupService.GetAllGroupStatusNames());
        }

        [HttpGet("getbyrequest")]
        public async Task<IActionResult> GetByRequestid(int requestId)
        {
            return Ok(await groupService.FindGroupsForRequest(requestId));

        }


        [HttpGet("getstudents")]
        public async Task<IActionResult> GetStudentsByGroupId(int groupId)
        {
            return Ok(await groupService.GetStudentsByGroupId(groupId));

        }
    }
}
