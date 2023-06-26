using DTO.Input.FromBody.Creation;
using FluentValidation;

namespace EFCoreService.InputDtoValidators.Creation
{
    public sealed class BrandForCreationValidator : AbstractValidator<BrandForCreationDto>
    {
        public BrandForCreationValidator() 
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("A required field")
                .MaximumLength(30).WithMessage("Maximum length is 30 characters.");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("A required field")
                .MaximumLength(100).WithMessage("Maximum length is 100 characters.");
        }
    }
}
