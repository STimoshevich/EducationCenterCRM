using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class CourseDTOValidator : AbstractValidator<CourseDTO>
    {

        public CourseDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(300);

            RuleFor(X=>X.Program)
                .NotEmpty()
                .NotNull()
                .MaximumLength(500);



        }
    }
}
