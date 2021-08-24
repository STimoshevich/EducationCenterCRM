using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.Services.BLL;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            try
            {
                return Ok(await studentService.GetAllAsync());
            }
            catch (System.Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
            
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpGet(ApiRoutes.Students.Get)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await studentService.GetByIdAsync(id);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpDelete(ApiRoutes.Students.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int Id)
        {
            try
            {
                var deleted = await studentService.DeleteByIdAsync(Id);
                return deleted ? NoContent() : NotFound();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }


        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPost(ApiRoutes.Students.Create)]
        public async Task<IActionResult> CreateNew([FromBody] StudentRequest studentRequest)
        {
            try
            {
                var created = await studentService.AddNewAsync(studentRequest);
                return created ? Ok() : BadRequest(new { error = "Unable to create student" });
            }
            catch (System.Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPut(ApiRoutes.Students.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id, [FromBody] StudentRequest studentRequest)
        {
            try
            {
                var updated = await studentService.UpdateAsync(Id, studentRequest);
                return updated ? Ok() : NotFound();
            }
            catch (System.Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }
    }
}
