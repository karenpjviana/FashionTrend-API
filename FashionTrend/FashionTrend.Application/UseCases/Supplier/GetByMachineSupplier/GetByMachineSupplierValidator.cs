using FluentValidation;

public sealed class GetByMachineSupplierValidator : AbstractValidator<GetByMachineSupplierRequest>
{
    public GetByMachineSupplierValidator()
    {
        RuleFor(x => x.Machine).NotEmpty();
    }
}
