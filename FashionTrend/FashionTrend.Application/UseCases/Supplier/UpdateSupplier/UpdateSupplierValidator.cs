using FluentValidation;

public sealed class UpdateSupplierValidator : AbstractValidator<UpdateSupplierRequest>
{
    public UpdateSupplierValidator()
    {
        //RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        //RuleFor(x => x.Email).NotEmpty().MinimumLength(3).EmailAddress();
        //RuleFor(x => x.Id).NotEmpty();
    }
}
