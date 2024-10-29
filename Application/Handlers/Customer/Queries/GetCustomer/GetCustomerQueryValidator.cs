using FluentValidation;

namespace Application.Handlers.Customer.Queries.GetCustomer;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThanOrEqualTo(0);
    }
}