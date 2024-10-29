using FluentValidation;

namespace Application.Handlers.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0);
    }
}