using Application.Handlers.Customer.Commands.InsertCustomer;

namespace Application.Handlers.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommand : InsertCustomerCommand
{
    public int Id { get; set; }
}