﻿using FluentValidation;

namespace EventSource.Application.Rider.Commands.Validators;

public sealed class AcceptOrderValidator : AbstractValidator<AcceptOrderCommand>
{
    public AcceptOrderValidator()
    {
        RuleFor(command => command.Id).NotEmpty().NotEqual(Guid.Empty);
    }
}
