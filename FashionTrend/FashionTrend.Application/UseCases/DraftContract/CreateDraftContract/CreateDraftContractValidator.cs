using FluentValidation;

public sealed class CreateDraftContractValidator : AbstractValidator<CreateDraftContractRequest>
{
    public CreateDraftContractValidator()
    {
        RuleFor(x => x.Supplier);
        RuleFor(x => x.Service);
        RuleFor(x => x.Description);
    }
}