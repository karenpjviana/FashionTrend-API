using FluentValidation;

public sealed class CreateServiceValidator : AbstractValidator<CreateServiceRequest>
{
    public CreateServiceValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Materials).NotEmpty();
    }
}
