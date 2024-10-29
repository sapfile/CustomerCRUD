using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Behaviours;

public class Performance<TReq, TRes>(ILogger<TReq> logger, Stopwatch stopwatch) : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
{
    public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        stopwatch.Start();

        var resp = await next();

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 1000)
        {
            logger.LogWarning($"Request: {typeof(TReq).Name} took longer than 1 second at {DateTime.UtcNow}, Please attention!");
        }

        return resp;
    }
}