using AutoMapper;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.PL.ApiContracts.V1.Routes;
using EducationCenterCRM.Services.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EducationCenterCRM.PL.Controllers.ApiControllers.V1
{
    [ApiController]
    public class GroupApiController : Controller
    {
        private readonly GroupService groupService;
        private readonly IMapper mapper;

        public GroupApiController(GroupService groupService, IMapper mapper)
        {
            this.groupService = groupService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all groups from database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns all groups from database</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Group.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(groupService.GetAllAsync());
        }


        /// <summary>
        /// Get group info by id
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns group info by id</response>
        /// <response code="404">Returns if group with setted id  does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(ApiRoutes.Group.Get)]
        public IActionResult GetById([FromRoute] int id)
        {
            if (id > 0)
            {
                var group = groupService.GetByIdOrDefaultAsync(id, includeRelations: false);

                if (group is not null)
                {
                    return Ok(group);
                }
            }

            return NotFound();
           
        }

        /// <summary>
        /// Create new group
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Returns if group was created</response>
        /// <response code="404">Returns if groupRequest is null </response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Group.Create)]
        public IActionResult CreateNewGroup([FromBody] Group groupRequest)
        {

            if (groupRequest is not null)
            {
              var maxId =   groupService.GetAllAsync().Max(x => x.Id); // TODO: rework
                groupRequest.Id = maxId + 1;                        // TODO: rework
                groupService.AddNewAsync(groupRequest);
                var url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(HttpContext.Request);
                return Created(url + "/" + groupRequest.Id, groupRequest);
            }

            return BadRequest();

        }

        /// <summary>
        /// Delete group by id
        /// </summary>
        /// <returns></returns>
        /// <response code="204">Returns if group was deleted</response>
        /// <response code="404">Returns if group does not exist </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete(ApiRoutes.Group.Delete)]
        public IActionResult DeleteGroup([FromRoute] int id)
        {

            if (id > 0)
            {
                groupService.DeleteById(id);
                return NoContent();
            }

            return NotFound();

        }

        /// <summary>
        /// Update group 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns if group was updated</response>
        /// <response code="404">Returns if group does not exist </response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(ApiRoutes.Group.Update)]
        public IActionResult DeleteGroup([FromBody] Group groupRequest)
        {
            if (groupRequest is not null)
            {
                groupService.Update(groupRequest);
                return Ok();
            }

            return BadRequest();

        }
    }
}

