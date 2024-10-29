using MediatR;

namespace Application.Handlers.Customer.Commands.DeleteCustomer;

public record DeleteCustomerCommand(int Id) : IRequest<bool>;