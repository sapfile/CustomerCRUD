using Application.Handlers.Customer.Queries.GetCustomer;
using MediatR;

namespace Application.Handlers.Customer.Queries.GetCustomerList;
public record GetCustomerListQuery : IRequest<List<GetCustomerModel>>;