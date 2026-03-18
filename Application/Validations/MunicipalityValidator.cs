using FluentValidation;
using Institution.Application.Dtos;

namespace Institution.Application.Validations;

public class MunicipalityValidator : AbstractValidator<MunicipalityDto>
{
    public MunicipalityValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name is required")
            .MinimumLength(3).WithMessage("The name must have at least 3 characters")
            .MaximumLength(50).WithMessage("The name cannot exceed 50 characters");
    }
}