using FluentValidation;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesDishes.Validators
{
    public class CreateDishValidator : AbstractValidator<DishDto>
    {
        public CreateDishValidator()
        {
            RuleFor(pr=>pr.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MaximumLength(50);

            RuleFor(pr => pr.Describition)
                .NotEmpty().WithMessage("Describition cannot be empty")
                .MaximumLength(100);

            RuleFor(pr => pr.Price)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
