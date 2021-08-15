using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EducationCenterCRM.DAL.Context;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class StudentsRepository : AbstractRepository<Student>
    {
        public StudentsRepository(EducationCenterDatabase context) : base(context)
        {

        }


       
    }
}
