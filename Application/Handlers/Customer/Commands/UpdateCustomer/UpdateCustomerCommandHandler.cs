using Mapster;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand, bool>
{
    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Customer>();

		try
		{
			await customerRepository.Update(entity, cancellationToken);

            return true;
        }
		catch (Exception)
		{
			throw;
        }
    }
}