using FluentValidation;

namespace EventSource.Application.Rider.Commands.Validators;
public sealed class UpdateLocationValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationValidator()
    {
        RuleFor(command => command.RirderId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}
