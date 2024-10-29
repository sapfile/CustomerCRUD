using FluentValidation;

namespace Application.Handlers.Customer.Commands.InsertCustomer;

public class InsertCustomerCommandValidator : AbstractValidator<InsertCustomerCommand>
{
    public InsertCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotNull()
            .NotEmpty();
    }
}