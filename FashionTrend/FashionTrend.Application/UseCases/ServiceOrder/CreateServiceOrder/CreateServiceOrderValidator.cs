using FluentValidation;

public sealed class CreateServiceOrderValidator : AbstractValidator<CreateServiceOrderRequest>
{
    public CreateServiceOrderValidator()
    {
        RuleFor(x => x.Supplier.Id).NotEmpty();
        RuleFor(x => x.Service.Id).NotEmpty();
        RuleFor(x => x.EstimetedDate).NotEmpty();
    }
}
