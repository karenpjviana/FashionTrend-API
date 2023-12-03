using FluentValidation;

public sealed class GetByServiceIdServiceOrderValidator : AbstractValidator<GetByServiceIdServiceOrderRequest>
{
    public GetByServiceIdServiceOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
