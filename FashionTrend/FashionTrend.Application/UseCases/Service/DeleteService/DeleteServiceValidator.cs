using FluentValidation;

public sealed class DeleteServiceValidator : AbstractValidator<DeleteServiceRequest>
{
    public DeleteServiceValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
