using FluentValidation;

public sealed class DeleteSupplierValidator : AbstractValidator<DeleteSupplierRequest>
{
    public DeleteSupplierValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
