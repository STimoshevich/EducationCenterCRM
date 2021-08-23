using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.DAL.Entities;

namespace EducationCenterCRM.WebApi.Controllers.V1
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;


        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        [HttpGet(ApiRoutes.Courses.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await courseService.GetAllAsync());
        }

        [Authorize(Roles = ApplicationRolles.Admin + "," + ApplicationRolles.Manager)]
        [HttpGet(ApiRoutes.Courses.Get)]
        public async Task<IActionResult> GetById(int id)
        {


            try
            {
                var result = await courseService.GetByIdAsync(id);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

        }

        [Authorize(Roles = ApplicationRolles.Admin + "," + ApplicationRolles.Manager)]
        [HttpDelete(ApiRoutes.Courses.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            try
            {
                var deleted = await courseService.DeleteByIdAsync(id);
                return deleted ? Ok() : NotFound();
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }


        }

        [Authorize(Roles = ApplicationRolles.Admin + "," + ApplicationRolles.Manager)]
        [HttpPost(ApiRoutes.Courses.Create)]
        public async Task<IActionResult> CreateNew([FromBody] CourseRequest courseRequest)
        {
            try
            {
                var created = await courseService.AddNewAsync(courseRequest);
                return created ? Ok() : BadRequest(new { error = "Unable to create course" });
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }

        }
        [Authorize(Roles = ApplicationRolles.Admin + "," + ApplicationRolles.Manager)]
        [HttpPut(ApiRoutes.Courses.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id, [FromBody] CourseRequest courseRequest)
        {
            var chek = ModelState;
            try
            {
                var updated = await courseService.UpdateAsync(Id, courseRequest);
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
