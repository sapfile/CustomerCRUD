using Mapster;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Queries.GetCustomer;

public class GetCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerQuery, GetCustomerModel>
{
    public async Task<GetCustomerModel> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customerEntity = await customerRepository.GetById(request.Id, cancellationToken);

        var customerDTO = customerEntity.Adapt<GetCustomerModel>();

        return customerDTO;
    }
}