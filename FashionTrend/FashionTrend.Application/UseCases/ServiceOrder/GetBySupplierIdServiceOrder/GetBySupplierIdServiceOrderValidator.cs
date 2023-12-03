using FluentValidation;

public sealed class GetBySupplierIdServiceOrderValidator : AbstractValidator<GetBySupplierIdServiceOrderRequest>
{
    public GetBySupplierIdServiceOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
