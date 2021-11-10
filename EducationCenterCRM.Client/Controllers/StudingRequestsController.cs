using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudingRequestsController : Controller
    {
        private readonly IStudingRequestService studingRequestService;

        public StudingRequestsController(IStudingRequestService studingRequestService)
        {
            this.studingRequestService = studingRequestService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewRequestAsync([FromBody] int courseId)
        {
            if (await studingRequestService.AddNewAsync(courseId))
                return Ok();
            return BadRequest();
        }


        [HttpGet("getallopen")]
        public async Task<IActionResult> GetAllOpen([FromQuery] int page = 1, int itemsPerPage = 4)
        {
            return Ok(await studingRequestService.GetAllOpenAsync(page, itemsPerPage));
        }
        [HttpGet("getallclosed")]
        public async Task<IActionResult> GetAllClosed([FromQuery] int page = 1, int itemsPerPage = 4)
        {
            return Ok(await studingRequestService.GetAllClosedAsync(page, itemsPerPage));
        }

        [HttpGet("getallstydingtypes")]
        public IActionResult GetAllStudingTypes()
        {
            return Ok(studingRequestService.GetAllStydingTypes());
        }

        [HttpPost("confirmrequest")]
        public IActionResult ConfirmRequest([FromBody] ConfirmRequestDTO confirmRequest)
        {
            return Ok(studingRequestService.ConfirmRequestAsync(confirmRequest.RequestId, confirmRequest.GroupId));
        }

    }
}

