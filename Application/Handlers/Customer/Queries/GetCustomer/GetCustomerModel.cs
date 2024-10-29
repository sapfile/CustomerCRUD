namespace Application.Handlers.Customer.Queries.GetCustomer;

public record GetCustomerModel()
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Surname { get; init; }

    public string? Email { get; init; }

    public int Age { get; init; }
}