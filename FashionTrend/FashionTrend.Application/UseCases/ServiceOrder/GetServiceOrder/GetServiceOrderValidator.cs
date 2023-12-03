using FluentValidation;

public sealed class GetServiceOrderValidator : AbstractValidator<GetServiceOrderRequest>
{
    public GetServiceOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
