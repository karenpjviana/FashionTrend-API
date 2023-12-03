using FluentValidation;

public sealed class CreateDraftContractValidator : AbstractValidator<CreateDraftContractRequest>
{
    public CreateDraftContractValidator()
    {
        RuleFor(x => x.ServiceOrder.Id);
        RuleFor(x => x.Description);
    }
}