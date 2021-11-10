using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await studentService.GetByUserIdAsync(id));
        }

    }
}
