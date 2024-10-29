using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public class Validation<TReq, TRes>(IEnumerable<IValidator<TReq>> validators) : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
{

    public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        var anyValidation = validators.Any();

        if (anyValidation)
        {
            var context = new ValidationContext<TReq>(request);

            var validations = validators.Select(v => v.ValidateAsync(context, cancellationToken));

            var validationResults = await Task.WhenAll(validations);

            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count > 0)
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}