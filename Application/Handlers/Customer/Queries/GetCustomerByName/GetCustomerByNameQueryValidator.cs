using FluentValidation;

namespace Application.Handlers.Customer.Queries.GetCustomerByName;

public class GetCustomerByNameQueryValidator : AbstractValidator<GetCustomerByNameQuery>
{
    public GetCustomerByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
    }
}