﻿using FluentValidation;

public sealed class CreateMessageValidator : AbstractValidator<CreateMessageRequest>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.topic).NotEmpty();
        RuleFor(x => x.content).NotEmpty();
    }
}
