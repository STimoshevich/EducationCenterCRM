using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Filterters.TeacherFilters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TeachersController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet("allnames")]
        public async Task<IActionResult> TeachersNamesWithIdAsync()
        {
            return Ok(await teacherService.GetAllNamesWithIdAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, int itemsPerPage = 4)
        {
            return Ok(await teacherService.GetAllAsync(page, itemsPerPage));
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await teacherService.GetByIdAsync(id));
        }

        [HttpPost("updateCourses")]
        public async Task<IActionResult> updateCourses([FromQuery] int teacherId, List<int> newCoursesid)
        {
            return Ok(await teacherService.UpdateTeacherCoursesAsync(teacherId, newCoursesid));
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] TeacherFilter filter, int page = 1, int itemsPerPage = 4)
        {
            var coursesResult = await teacherService.GetByFilter(filter, page, itemsPerPage);
            return Ok(coursesResult);
        }
    }
}
