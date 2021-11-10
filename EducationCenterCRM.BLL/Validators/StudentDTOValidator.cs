using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.DTO;
using FluentValidation;
using System;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class StudentDTOValidator : AbstractValidator<StudentDTO>
    {
        public StudentDTOValidator()
        {
            RuleForEach(x => x.Name)
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
            RuleFor(x => x.BirthDate)
                .Custom((x, context) => {
                    var age = ((DateTime.Now - x).TotalDays / 365);
                    if (age < 18)
                    {
                        context.AddFailure("Age shoul be greater than 18");
                    }
                });
            RuleFor(x => x.GroupId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
