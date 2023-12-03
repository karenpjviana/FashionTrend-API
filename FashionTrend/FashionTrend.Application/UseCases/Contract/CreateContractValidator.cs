using FluentValidation;

public sealed class CreateContractValidator : AbstractValidator<CreateContractRequest>
{
    public CreateContractValidator()
    {
        RuleFor(x => x.Description).NotEmpty();   
    }
}