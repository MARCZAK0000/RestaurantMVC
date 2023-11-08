using FluentValidation;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Command.Validators
{
    public class ChangePasswordValidator:AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(pr => pr.NewPassword)
               .NotEmpty()
               .MinimumLength(6).WithMessage("Password has to have atleast 6 digits")
               .MaximumLength(18).WithMessage("Password has to have atleast 18 digits")
               .Custom((value, context) =>
               {
                   if (string.IsNullOrWhiteSpace(value))
                   {
                       context.AddFailure("Password has whitespaces");
                   }
               });


            RuleFor(pr => pr.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password has to have atleast 6 digits")
                .MaximumLength(18).WithMessage("Password has to have atleast 18 digits");

        }
    }
}
