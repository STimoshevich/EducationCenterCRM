using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class TeacherRequestValidator : AbstractValidator<TeacherRequest>
    {
        public TeacherRequestValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull();
            RuleFor(x => x.Lastname)
                 .NotEmpty()
                 .NotNull();
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .NotNull();
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Phone)
               .NotEmpty()
               .NotNull();
            RuleFor(x => x.Phone)
               .NotEmpty()
               .NotNull();
            RuleFor(x => x.BirthDate)
                .Custom((x, context) => {

                    var age = ((DateTime.Now - x).TotalDays / 365);
                    if (age < 18)
                    {
                        context.AddFailure("Age shoul be greater than 18");
                    }
                });
        }
    }

  
    //public string Bio { get; set; }
    //public string LinkToProfile { get; set; }
}
