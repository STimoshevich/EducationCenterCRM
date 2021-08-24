using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using EducationCenterCRM.Services.BLL;

namespace EducationCenterCRM.WebApi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet(ApiRoutes.Teachers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await teacherService.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpGet(ApiRoutes.Teachers.Get)]
        public async Task<IActionResult> GetById(int id )
        {
            try
            {
                var result = await teacherService.GetByIdAsync(id);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {

                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpDelete(ApiRoutes.Teachers.Delete)]
        public async Task<IActionResult> DeleteById([FromQuery] int Id)
        {
            try
            {
                var deleted = await teacherService.DeleteByIdAsync(Id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
           
        }


        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPost(ApiRoutes.Teachers.Create)]
        public async Task<IActionResult> CreateNew([FromBody] TeacherRequest teacherRequest)
        {
            try
            {
                var created = await teacherService.AddNewAsync(teacherRequest);
                return created ? Ok() : BadRequest(new { error = "Unable to create teacher" });
            }
            catch (Exception ex)
            {
                Log.Error(ex?.Message);
                Log.Error(ex?.InnerException?.Message);

                return BadRequest();
            }
            
        }

        [Authorize(Roles = ApplicationRoles.Admin + "," + ApplicationRoles.Manager)]
        [HttpPut(ApiRoutes.Teachers.Update)]
        public async Task<IActionResult> Update([FromQuery] int Id, [FromBody] TeacherRequest teacherRequest)
        {
            try
            {
                var updated = await teacherService.UpdateAsync(Id, teacherRequest);
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
