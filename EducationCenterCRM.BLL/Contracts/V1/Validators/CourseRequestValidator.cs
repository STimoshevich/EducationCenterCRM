using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class CourseRequestValidator : AbstractValidator<CourseRequest>
    {

        public CourseRequestValidator()
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


            RuleFor(X => X.TopicId)
               .GreaterThan(0);

        }
    }
}
