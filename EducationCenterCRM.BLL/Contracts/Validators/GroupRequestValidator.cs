using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.Validators
{
    public class GroupRequestValidator : AbstractValidator<GroupRequest>
    {
        public GroupRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();
        }
    }
}
