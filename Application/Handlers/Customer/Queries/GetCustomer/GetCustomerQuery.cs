using MediatR;

namespace Application.Handlers.Customer.Queries.GetCustomer;

public record GetCustomerQuery(int Id) : IRequest<GetCustomerModel>;