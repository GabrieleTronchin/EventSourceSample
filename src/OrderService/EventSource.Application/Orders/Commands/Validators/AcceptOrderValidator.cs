using EventSource.Application.Orders.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSource.Application.Orders.Commands.Validators;


public sealed class AcceptOrderValidator : AbstractValidator<AcceptOrderCommand>
{
    public AcceptOrderValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}
