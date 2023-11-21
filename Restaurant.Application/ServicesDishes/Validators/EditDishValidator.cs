using FluentValidation;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesDishes.Validators
{
    public class EditDishValidator : AbstractValidator<EditDishDto>
    {
        public EditDishValidator()
        {
            RuleFor(pr=>pr.Price)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(10000);
        }
    }
}
