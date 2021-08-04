using Microsoft.AspNetCore.Mvc;
using EducationCenterCRM.PresentationLayer.Models;
using AutoMapper;
using System.Linq;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;
using EducationCenterCRM.Services.BLL;

namespace EducationCenterCRM.PresentationLayer.Controllers
{

    public class StudentsController : Controller
    {
        private readonly StudentService studentService;
        private readonly IMapper mapper;

        public StudentsController(StudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("/[controller]")]
        public IActionResult GetAll()
        {
            var result = mapper.Map<IEnumerable<StudentViewModel>>(studentService.GetAll()).OrderBy(x => x.Id) ;

            return View("MainList", result);
        }




        [HttpPost]
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                var res = studentService.GetByIdOrDefault(id,includeRelations: true);

                if (res is not null)
                {
                    return PartialView("StudentInfo", res);
                }
                    
            }
               
            return base.PartialView("StudentInfo", new Student());

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            studentService.DeleteById(id);
            return RedirectToAction("GetAll");
        }


        [HttpPost]
        [Route("[controller]/edit")]
        public IActionResult EditPartialView(int id)
        {
            if (id > 0)
            {
                var res = studentService.GetByIdOrDefault(id, includeRelations: true);
                if (res is not null)
                    return base.PartialView("StudentEdit", res);
            }

            return base.PartialView("StudentEdit", new Student());
        }

        [HttpPost]
        public IActionResult UpdateOrCreate(Student editedData)
        {
            if (ModelState.IsValid)
            {
                if (studentService.GetByIdOrDefault(editedData.Id,includeRelations: false) is null)
                    studentService.AddNew(editedData);
                else
                    studentService.Update(editedData);
                return Content(""); // TODO:rework?
            }
            
            return PartialView("StudentEdit", editedData);

        }


    }
}
