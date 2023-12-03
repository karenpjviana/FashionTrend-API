using FluentValidation;

public sealed class AcceptedDraftContractValidator : AbstractValidator<AcceptedDraftContractRequest>
{
    public AcceptedDraftContractValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}