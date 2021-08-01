using AutoMapper;
using EducationCenterCRM.DAL.Infrastructure;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EducationCenterCRM.Services.BLL;
using System.Collections.Generic;

namespace EducationCenterCRM.PresentationLayer.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeacherService teacherService;
        private readonly IMapper mapper;

        public TeachersController(TeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetAll()
        {
            var teachers = mapper.Map<IEnumerable<TeacherViewModel>>(teacherService.GetAll()).OrderBy(x => x.Id);
            return View("MainList", teachers);
        }




        [HttpPost]
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var res = teacherService.GetByIdOrDefault(id,includeRelations: true);

                if (res is not null)
                {
                    return PartialView("TeacherInfo", res);
                }
            }
            return PartialView("TeacherInfo", new Teacher());

        }

      


        [HttpPost]
        public IActionResult Delete(int id)
        {
            teacherService.DeleteById(id);
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public IActionResult Add(Teacher data)
        {
            if (ModelState.IsValid)
            {
                teacherService.AddNew(data);
                return Ok();
            }

            return PartialView("TeacherEdit", data);
        }

        [HttpPost]
        [Route("[controller]/edit")]
        public IActionResult EditPartialView(int id)
        {
            if (id > 0)
            {
                var teacher = teacherService.GetByIdOrDefault(id, includeRelations: true);
                return PartialView("TeacherEdit", teacher);
            }

            return PartialView("TeacherEdit", new Teacher());

        }

        [HttpPost]
        public IActionResult UpdateOrCreate(Teacher editedData)
        {
            if (ModelState.IsValid)
            {
                if (teacherService.GetByIdOrDefault(editedData.Id, includeRelations: false) is null)
                    teacherService.AddNew(editedData);
                else
                    teacherService.Update(editedData);
                return Ok();
            }

            return PartialView("TeacherEdit", editedData);

        }

    }
}
