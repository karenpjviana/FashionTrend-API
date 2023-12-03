using FluentValidation;

public sealed class GetByTypeServiceValidator : AbstractValidator<GetByTypeServiceRequest>
{
    public GetByTypeServiceValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
    }
}
