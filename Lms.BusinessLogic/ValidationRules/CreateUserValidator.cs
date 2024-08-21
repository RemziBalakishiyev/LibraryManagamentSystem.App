using FluentValidation;
using Lms.BusinessLogic.Dtos;

namespace Lms.BusinessLogic.ValidationRules;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required");

        RuleFor(x => x.LastName)
           .NotEmpty()
           .WithMessage("Last Name is required");

        RuleFor(x => x.Email)
         .NotEmpty()
         .WithMessage("Mail is required");


        RuleFor(x => x.Email)
         .EmailAddress()
         .WithMessage("Mail is not correct format");


        RuleFor(x => x.Password)
          .NotEmpty()
          .WithMessage("Password is required");
    }
}
