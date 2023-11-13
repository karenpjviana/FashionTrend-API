using FluentValidation;

public sealed class GetSupplierValidator : AbstractValidator<GetSupplierRequest>
{
    public GetSupplierValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
