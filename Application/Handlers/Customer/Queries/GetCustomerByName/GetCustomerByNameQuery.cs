using Application.Handlers.Customer.Queries.GetCustomer;
using MediatR;

namespace Application.Handlers.Customer.Queries.GetCustomerByName;

public record GetCustomerByNameQuery(string Name) : IRequest<List<GetCustomerModel>>;