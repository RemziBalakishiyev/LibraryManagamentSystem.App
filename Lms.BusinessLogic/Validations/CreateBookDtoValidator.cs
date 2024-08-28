using FluentValidation;
using Lms.BusinessLogic.Dtos;

namespace Lms.BusinessLogic.Validations
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(3)
                .WithMessage("Name must be greater than 3 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(10)
                .WithMessage("Description must be at least 10 characters long");

            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("Price is required")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a positive value")
                .LessThanOrEqualTo(1000)
                .WithMessage("Price must be less than or equal to 1000");



            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Category is required");

        }
    }

}
