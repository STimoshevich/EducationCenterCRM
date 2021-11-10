using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Validators
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.Token)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.RefreshToken)
                .NotNull()
                .NotEmpty();
        }
    }
}
