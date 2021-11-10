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


        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var headers = Request.Headers;
            return Ok(await courseService.GetAllAsync());
        }

       
        //public async Task<IActionResult> GetById(int id)
        //{


        //    try
        //    {
        //        var result = await courseService.GetByIdAsync(id);
        //        return result is not null ? Ok(result) : NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        Log.Error(ex?.Message);
        //        Log.Error(ex?.InnerException?.Message);

        //        return BadRequest();
        //    }

        //}

        //[Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        //[HttpDelete(ApiRoutes.Courses.Delete)]
        //public async Task<IActionResult> DeleteById([FromQuery] int id)
        //{
        //    try
        //    {
        //        var deleted = await courseService.DeleteByIdAsync(id);
        //        return deleted ? Ok() : NotFound();
        //    }
        //    catch (Exception ex)
        //    {

        //        Log.Error(ex?.Message);
        //        Log.Error(ex?.InnerException?.Message);

        //        return BadRequest();
        //    }


        //}

        //[Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        //[HttpPost(ApiRoutes.Courses.Create)]
        //public async Task<IActionResult> CreateNew([FromBody] CourseRequest courseRequest)
        //{
        //    try
        //    {
        //        var created = await courseService.AddNewAsync(courseRequest);
        //        return created ? Ok() : BadRequest(new { error = "Unable to create course" });
        //    }
        //    catch (Exception ex)
        //    {

        //        Log.Error(ex?.Message);
        //        Log.Error(ex?.InnerException?.Message);

        //        return BadRequest();
        //    }

        //}
        //[Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        //[HttpPut(ApiRoutes.Courses.Update)]
        //public async Task<IActionResult> Update([FromQuery] int Id, [FromBody] CourseRequest courseRequest)
        //{
        //    var chek = ModelState;
        //    try
        //    {
        //        var updated = await courseService.UpdateAsync(Id, courseRequest);
        //        return updated ? Ok() : NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex?.Message);
        //        Log.Error(ex?.InnerException?.Message);

        //        return BadRequest();
        //    }

        //}
    }
}
