using MediatR;

namespace Application.Handlers.Customer.Commands.InsertCustomer;

public class InsertCustomerCommand : IRequest<bool>
{
    public string? Name { get; set; }
    
    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int Age { get; set; }
}