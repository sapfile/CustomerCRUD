using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours;

public class Logging<TReq>(ILogger<TReq> logger) : IRequestPreProcessor<TReq>
{
    public async Task Process(TReq request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"{typeof(TReq).Name} has requested! at {DateTime.UtcNow}");
    }
}