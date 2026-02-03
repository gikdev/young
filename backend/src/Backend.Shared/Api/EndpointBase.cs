using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Backend.Shared.Api;

public abstract class EndpointBase {
    public abstract ApiRoute Route { get; }

    public abstract void MapEndpoint(IEndpointRouteBuilder app);

    protected static IResult Problem(List<Error> errors) {
        if (errors.Count == 0)
            return TypedResults.Problem();

        return errors.All(e => e.Type == ErrorType.Validation)
            ? ValidationProblem(errors)
            : Problem(errors[0]);
    }

    protected static IResult Problem(Error error) {
        var statusCode = error.Type switch {
            ErrorType.Conflict     => StatusCodes.Status409Conflict,
            ErrorType.Validation   => StatusCodes.Status400BadRequest,
            ErrorType.NotFound     => StatusCodes.Status404NotFound,
            ErrorType.Forbidden    => StatusCodes.Status403Forbidden,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _                      => StatusCodes.Status500InternalServerError
        };

        return TypedResults.Problem(
            statusCode: statusCode,
            detail: error.Description,
            title: error.Code
        );
    }

    protected static IResult ValidationProblem(List<Error> errors) {
        // Convert to the RFC 7807 validation dictionary format
        var errorDictionary = errors
            .GroupBy(e => e.Code)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.Description).ToArray()
            );

        return TypedResults.ValidationProblem(errorDictionary);
    }
}
