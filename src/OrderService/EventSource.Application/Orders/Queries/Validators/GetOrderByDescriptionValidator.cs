using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSource.Application.Orders.Queries.Validators;

public sealed class GetOrderByDescriptionValidator
: AbstractValidator<GetOrdersByDescriptionCommand>
{
    public GetOrderByDescriptionValidator()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage("Description cloud not be empty");
    }
}
