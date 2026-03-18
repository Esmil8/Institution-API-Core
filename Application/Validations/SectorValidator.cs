using FluentValidation;
using Institution.Application.Dtos;

public class SerctorValidator : AbstractValidator<SectorDto>
{
    public SerctorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name is required")
            .MinimumLength(3).WithMessage("The name must have at least 3 characters")
            .MaximumLength(50).WithMessage("The name cannot exceed 50 characters");
        
        RuleFor(x => x.MunicipalityId)
            .NotEmpty().WithMessage("The municipality is required");
    }
}