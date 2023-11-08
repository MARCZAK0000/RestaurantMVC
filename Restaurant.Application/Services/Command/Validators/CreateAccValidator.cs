using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Command.Validators
{
    public class CreateAccValidator : AbstractValidator<Domain.Dto.CreateAccountDto>
    {

        public CreateAccValidator(UserManager<IdentityUser> userManager)
        {
            RuleFor(pr => pr.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("It has to be an Email")
                .MinimumLength(5).WithMessage("It has to have atleast 5 digits")
                .MaximumLength(50).WithMessage("It has to have less than 50 digits")
                .Custom((value, context) =>
                {
                    var result = userManager.FindByEmailAsync(value).Result;

                    if(result is not null)
                    {
                        context.AddFailure("Email is in used");
                    }
                });


            RuleFor(pr => pr.Password)
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
