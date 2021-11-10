using EducationCenterCRM.BLL.DTO;
using FluentValidation;
using System;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class TeacherDTOValidator : AbstractValidator<TeacherDTO>
    {
        public TeacherDTOValidator()
        {
          
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
