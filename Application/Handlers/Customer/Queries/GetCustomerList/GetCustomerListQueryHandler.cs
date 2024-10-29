using Application.Handlers.Customer.Queries.GetCustomer;
using Mapster;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Queries.GetCustomerList;

public class GetCustomerListQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerListQuery, List<GetCustomerModel>>
{
    public async Task<List<GetCustomerModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        var customerEntities = await customerRepository.GetList(cancellationToken);

        var dtos = customerEntities.Adapt<List<GetCustomerModel>>();

        return dtos;
    }
}