using FluentValidation;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Command.Validators
{
    public class ChangePhoneNumberValidator:AbstractValidator<ChangePhoneDto>
    {
        public ChangePhoneNumberValidator()
        {
            RuleFor(pr => pr.NewPhoneNumber)
                .NotEmpty().WithMessage("New phone number is required")
                .Length(12).WithMessage("Phone number has to have 12 digits");
                
        }
    }
}
