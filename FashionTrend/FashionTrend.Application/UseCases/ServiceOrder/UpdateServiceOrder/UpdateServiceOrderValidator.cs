using FluentValidation;

public sealed class UpdateServiceOrderValidator : AbstractValidator<UpdateServiceOrderRequest>
{
    public UpdateServiceOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
    }
}
