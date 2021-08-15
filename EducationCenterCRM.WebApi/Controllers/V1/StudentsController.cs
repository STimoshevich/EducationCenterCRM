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
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet(ApiRoutes.Students.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await studentService.GetAllAsync());
        }

        [HttpGet(ApiRoutes.Students.Get)]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            return Ok(await studentService.GetByIdAsync(Id));
        }

        [HttpDelete(ApiRoutes.Students.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int Id)
        {
            var deleted = await studentService.DeleteByIdAsync(Id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpPost(ApiRoutes.Students.Create)]
        public async Task<IActionResult> CreateNew([FromBody] StudentRequest studentRequest)
        {
            var created = await studentService.AddNewAsync(studentRequest);
            return created ? Ok() : BadRequest(new { error = "Unable to create student" });
        }
        [HttpPut(ApiRoutes.Students.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id, [FromBody] StudentRequest studentRequest)
        {
            var updated = await studentService.UpdateAsync(Id, studentRequest);
            return updated ? Ok() : NotFound();
        }
    }
}
