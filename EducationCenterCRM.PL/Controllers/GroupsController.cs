using AutoMapper;
using EducationCenterCRM.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;
using EducationCenterCRM.Services.BLL;
using Newtonsoft.Json.Linq;

namespace EducationCenterCRM.PresentationLayer.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GroupsController : Controller
    {
        private readonly GroupService groupService;
        private readonly IMapper mapper;

        public GroupsController(GroupService groupService, IMapper mapper)
        {
            this.groupService = groupService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetAll()
        {
            var group = mapper.Map<IEnumerable<GroupViewModel>>(groupService.GetAll()).OrderBy(x => x.Id);

            return View("MainList", group);
        }

        [HttpPost]
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var group = groupService.GetByIdOrDefault(id,includeRelations: true);

                if (group is not null)
                {
                    return PartialView("GroupInfo", group);
                }
            }


            return PartialView("GroupInfo", new Group());

        }

      


        [HttpPost]
        public IActionResult Delete(int id)
        {
            groupService.DeleteById(id);
            return RedirectToAction("GetAll");
        }


        [HttpPost]
        [Route("[controller]/edit")]
        public IActionResult EditPartialView(int id)
        {
            if (id > 0)
            {
                var group = groupService.GetByIdOrDefault(id, includeRelations: true);

                if (group is not null)
                    return PartialView("GroupEdit", group);

            }

            return PartialView("GroupEdit", new Group());

        }

        [HttpPost]
        public IActionResult UpdateOrCreate(Group editedData)
        {
            if (ModelState.IsValid)
            {
                if (groupService.GetByIdOrDefault(editedData.Id, includeRelations: false) is null)
                    groupService.AddNew(editedData);
                else
                    groupService.Update(editedData);
                return Content(""); // TODO:rework?
            }

            return PartialView("GroupEdit", editedData);

        }
    }
}
