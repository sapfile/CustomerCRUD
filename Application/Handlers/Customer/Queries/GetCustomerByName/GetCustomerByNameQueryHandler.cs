using Application.Handlers.Customer.Queries.GetCustomer;
using Mapster;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Queries.GetCustomerByName;

public class GetCustomerByNameQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerByNameQuery, List<GetCustomerModel>>
{
    public async Task<List<GetCustomerModel>> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
    {
        var customerEntities = await customerRepository.GetList(x => x.Name == request.Name, cancellationToken);

        var customerListDto = customerEntities.Adapt<List<GetCustomerModel>>();

        return customerListDto;
    }
}