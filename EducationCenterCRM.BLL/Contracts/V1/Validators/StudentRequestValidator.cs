using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using FluentValidation;
using System;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
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
            RuleFor(x => x.Type)
                .IsInEnum();
            RuleFor(x => x.GroupId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
