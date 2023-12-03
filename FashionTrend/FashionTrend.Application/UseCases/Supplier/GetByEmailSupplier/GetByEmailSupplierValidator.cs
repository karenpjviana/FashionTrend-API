using FluentValidation;

public sealed class GetByEmailSupplierValidator : AbstractValidator<GetByEmailSupplierRequest>
{
    public GetByEmailSupplierValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
