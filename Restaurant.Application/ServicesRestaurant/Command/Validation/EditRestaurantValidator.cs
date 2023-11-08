using FluentValidation;
using Restaurant.Domain.Dto;

namespace Restaurant.Application.ServicesRestaurant.Command.Validation
{
    public class EditRestaurantValidator:AbstractValidator<EditRestaurantDto>
    {
        public EditRestaurantValidator()
        {
            RuleFor(pr => pr.NewName)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Name has to have atleast 5 digits")
                .MaximumLength(50).WithMessage("Name has to have less than 50 digits");

            RuleFor(pr => pr.NewDescription)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Description has to have atleast 5 digits")
                .MaximumLength(100).WithMessage("Description has to have less than 100 digits");

            RuleFor(pr => pr.NewTypes)
                .NotEmpty()
                .IsInEnum();

            RuleFor(pr => pr.NewStreet)
               .NotEmpty()
               .MinimumLength(5).WithMessage("Street has to have atleast 5 digits")
               .MaximumLength(50).WithMessage("Street has to have less than 50 digits");

            RuleFor(pr => pr.NewCity)
               .NotEmpty()
               .MinimumLength(5).WithMessage("City has to have atleast 5 digits")
               .MaximumLength(50).WithMessage("Cityhas to have less than 50 digits");

            RuleFor(pr => pr.NewPostalCode)
               .NotEmpty()
               .Length(6).WithMessage("Postal code has to have 6 digits");

            RuleFor(pr => pr.NewPostalCity)
               .NotEmpty()
               .MinimumLength(5).WithMessage("City has to have atleast 5 digits")
               .MaximumLength(100).WithMessage("City has to have less than 50 digits");

            RuleFor(pr => pr.NewPhoneNumber)
               .NotEmpty()
               .Length(12).WithMessage("Phone number has to have 12 digits");


            RuleFor(pr => pr.NewEmail)
                .NotEmpty()
                .EmailAddress().WithMessage("It has to be an Email")
                .MinimumLength(5).WithMessage("Email has to have atleast 5 digits")
                .MaximumLength(50).WithMessage("Email has to have less than 50 digits");


        }
    }

}
