using FluentValidation;

public sealed class CreateServiceOrderValidator : AbstractValidator<CreateServiceOrderRequest>
{
    public CreateServiceOrderValidator()
    {
        RuleFor(x => x.ServiceId).NotEmpty();
        RuleFor(x => x.SupplierId).NotEmpty();
    }
}
