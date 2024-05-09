using FluentValidation;

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
