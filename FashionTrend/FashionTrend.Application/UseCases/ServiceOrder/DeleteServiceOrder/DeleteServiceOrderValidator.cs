using FluentValidation;

public sealed class DeleteServiceOrderValidator : AbstractValidator<DeleteServiceOrderRequest>
{
    public DeleteServiceOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
