using FluentValidation;

public sealed class GetByMaterialSupplierValidator : AbstractValidator<GetByMaterialSupplierRequest>
{
    public GetByMaterialSupplierValidator()
    {
        RuleFor(x => x.Material).NotEmpty();
    }
}
