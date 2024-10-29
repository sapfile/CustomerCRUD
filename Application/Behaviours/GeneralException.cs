using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours;

public class GeneralException<TReq, TRes>(ILogger<TReq> logger) : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
{
    public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            logger.LogError($"Request: {typeof(TReq).Name} got exception error at {DateTime.UtcNow}, Error message is: {ex.Message}, Please take a look!");

            throw;
        }
    }
}