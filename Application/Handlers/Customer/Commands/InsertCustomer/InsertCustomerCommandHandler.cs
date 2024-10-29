using Domain.Entities;
using Mapster;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Commands.InsertCustomer;

public class InsertCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<InsertCustomerCommand, bool>
{
    public async Task<bool> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Customer>();

		try
		{
			await customerRepository.Insert(entity, cancellationToken);

            return true;
        }
		catch (Exception ex)
		{
			throw;
		}
    }
}