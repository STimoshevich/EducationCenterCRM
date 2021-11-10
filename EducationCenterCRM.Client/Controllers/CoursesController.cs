using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Filteres.CourseFilters;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll([FromQuery]int page = 1,int itemsPerPage = 4)
        {
    

                var result = await courseService.GetAllAsync(page,itemsPerPage);
                return Ok(result);
        
 

        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] CourseFilter filter, int page = 1, int itemsPerPage = 4)
        {
            var coursesResult = await courseService.GetByFilter(filter,page,itemsPerPage);
            return Ok(coursesResult);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchString, int page = 1, int itemsPerPage = 4)
        {
            var coursesResult = await courseService.SearchAsync(searchString,page,itemsPerPage);
            return Ok(coursesResult);
        }



        [HttpGet("courselvlNames")]
        public IActionResult GetAllCourseLvls()
        {
            return Ok(courseService.GetAllCourseLvls());
        }


       

        [HttpGet("alltitles")]
        public async Task<IActionResult> GetAllTitlesAsync()
        {
            return Ok(await courseService.GetAllTitlesWithId());
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {

                var result = await courseService.GetByIdAsync(id);
                return result is not null ? Ok(result) : NotFound();
   

        }



        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {

                var deleted = await courseService.DeleteByIdAsync(id);
                return deleted ? Ok() : NotFound();



        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] CourseDTO courseRequest)
        {


                var created = await courseService.AddNewAsync(courseRequest);
                return created ? Ok() : BadRequest(new { error = "Unable to create course" });


        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] CourseDTO courseRequest)
        {

                var updated = await courseService.UpdateAsync(courseRequest);
                return updated ? Ok() : NotFound();



        }

        [HttpGet("getteachers")]
        public async Task<IActionResult> GetCourseTeachers(int courseId)
        {
            return Ok(await courseService.AllTeachersNamesWithIdbyCourse(courseId));

        }





    }
}
