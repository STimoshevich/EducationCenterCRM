using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using EducationCenterCRM.BLL.Services.Interfaces;

namespace EducationCenterCRM.WebApi.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;


        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await courseService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);
            }
            return BadRequest();
           
        }

        //[HttpGet("[controller]/{id}")]
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

        [HttpDelete]
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

        [HttpPost]
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

        [HttpPut]
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
