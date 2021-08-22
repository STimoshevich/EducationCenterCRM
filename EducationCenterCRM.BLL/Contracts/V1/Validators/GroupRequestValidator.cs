using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.Validators
{
    public class GroupRequestValidator : AbstractValidator<GroupRequest>
    {
        public GroupRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now - TimeSpan.FromDays(150));

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.TeacherId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
