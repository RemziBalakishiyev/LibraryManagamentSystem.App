using FluentValidation;
using Lms.BusinessLogic.Dtos;

namespace Lms.BusinessLogic.ValidationRules;

public class SigninUserDtoValidator : AbstractValidator<SigninUserDto>
{
    public SigninUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Incorrect email format");

        RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("Email is required");

        RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("Password is required");
    }
}
