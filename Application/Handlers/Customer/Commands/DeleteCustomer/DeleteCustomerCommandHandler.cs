using MediatR;
using Repository.Interfaces;

namespace Application.Handlers.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
		try
		{
			await customerRepository.Delete(request.Id, cancellationToken);

            return true;
        }
		catch (Exception)
		{

			throw;
		}
    }
}