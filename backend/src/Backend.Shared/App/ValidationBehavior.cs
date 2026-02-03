using ErrorOr;
using FluentValidation;
using MediatR;

namespace Backend.Shared.App;

public class ValidationBehavior<TReq, TRes>(
    IValidator<TReq>? validator = null
) : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
    where TRes : IErrorOr {
    public async Task<TRes> Handle(
        TReq                         request,
        RequestHandlerDelegate<TRes> next,
        CancellationToken            ct
    ) {
        if (validator is null) return await next(ct);

        var result = await validator.ValidateAsync(request, ct);
        if (result.IsValid) return await next(ct);

        var errors = result.Errors
            .Select(e => Error.Validation(
                e.PropertyName,
                e.ErrorMessage
            ))
            .ToList();

        return (dynamic)errors;
    }
}
