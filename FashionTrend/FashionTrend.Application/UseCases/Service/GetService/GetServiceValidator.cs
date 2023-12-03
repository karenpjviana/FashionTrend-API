using FluentValidation;

public sealed class GetServiceValidator : AbstractValidator<GetServiceRequest>
{
    public GetServiceValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
