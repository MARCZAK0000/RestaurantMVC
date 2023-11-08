using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Command.Validators
{
    public class SignInValidator : AbstractValidator<SignInDto>
    {
        public SignInValidator(UserManager<IdentityUser> userManager)
        {
            RuleFor(pr => pr.Email)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Email has to have more than 5 digits")
                .MaximumLength(50).WithMessage("Email has to have less than 50 digits")
                .Custom((value, context) =>
                {
                    var find = userManager.FindByEmailAsync(value).Result;
                    if (find is null)
                    {
                        context.AddFailure("Invalid username or password");
                    };
                });


            RuleFor(pr => pr.Password)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Email has to have more than 6 digits")
                .MaximumLength(18).WithMessage("Email has to have less than 18 digits");
                
        }
    }
}
