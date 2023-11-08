using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ServicesRestaurant.Command.Validation
{
    public class CreateRestaurantValidator : AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestaurantValidator()
        {
            RuleFor(pr => pr.Name)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Name has to have atleast 5 digits")
                .MaximumLength(50).WithMessage("Name has to have less than 50 digits");

            RuleFor(pr => pr.Description)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Description has to have atleast 5 digits")
                .MaximumLength(100).WithMessage("Description has to have less than 100 digits");

            RuleFor(pr => pr.Type)
                .NotEmpty()
                .IsInEnum();

            RuleFor(pr => pr.Street)
               .NotEmpty()
               .MinimumLength(5).WithMessage("Street has to have atleast 5 digits")
               .MaximumLength(50).WithMessage("Street has to have less than 50 digits");

            RuleFor(pr => pr.City)
               .NotEmpty()
               .MinimumLength(5).WithMessage("City has to have atleast 5 digits")
               .MaximumLength(50).WithMessage("Cityhas to have less than 50 digits");

            RuleFor(pr => pr.PostalCode)
               .NotEmpty()
               .Length(6).WithMessage("Postal code has to have 6 digits");

            RuleFor(pr => pr.PostalCity)
               .NotEmpty()
               .MinimumLength(5).WithMessage("City has to have atleast 5 digits")
               .MaximumLength(100).WithMessage("City has to have less than 50 digits");

            RuleFor(pr => pr.PhoneNumber)
               .NotEmpty()
               .Length(12).WithMessage("Phone number has to have 12 digits");


            RuleFor(pr => pr.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("It has to be an Email")
                .MinimumLength(5).WithMessage("Email has to have atleast 5 digits")
                .MaximumLength(50).WithMessage("Email has to have less than 50 digits");

            RuleFor(pr => pr.Country)
               .NotEmpty()
               .MinimumLength(3).WithMessage("Street has to have atleast 3 digits")
               .MaximumLength(50).WithMessage("Street has to have less than 50 digits");
        }
    }
}
