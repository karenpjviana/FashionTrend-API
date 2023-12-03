using FluentValidation;

public sealed class UpdateServiceValidator : AbstractValidator<UpdateServiceRequest>
{
    public UpdateServiceValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Description).NotEmpty().MinimumLength(2);
        RuleFor(x => x.SewingMachines).NotEmpty();
        RuleFor(x => x.Materials).NotEmpty();
    }
}
