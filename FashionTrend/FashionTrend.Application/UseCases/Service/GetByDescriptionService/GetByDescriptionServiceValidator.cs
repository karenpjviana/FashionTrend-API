using FluentValidation;

public sealed class GetByDescriptionServiceValidator : AbstractValidator<GetByDescriptionServiceRequest>
{
    public GetByDescriptionServiceValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}
