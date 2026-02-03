using Backend.Api.Contracts.Sessions;
using Backend.Shared.Api;
using Backend.Shared.Api.Endpoints;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Backend.Api.Sessions.Endpoints;

internal class CreateSessionEndpoint : EndpointBase {
    public override ApiRoute Route => ApiEndpoints.Sessions.CreateSession;

    public override void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapMethods(Route.Path, Route.Methods, Handle)
            .WithName(Route.Name)
            .WithSummary(Route.Summary)
            .WithTags(Route.Tag)
            .Accepts<CreateSessionRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status401Unauthorized);
    }

    private static async Task<IResult> Handle(
        [FromServices] ILogger<CreateSessionEndpoint>   logger,
        [FromServices] ISender                          mediator,
        [FromServices] IValidator<CreateSessionRequest> validator,
        [FromBody]     CreateSessionRequest             request
    ) {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

        logger.LogDebug("Request received.");

        var result = await mediator.Send(request.MapToCommand());

        if (result.IsError) {
            var errors = result.Errors;
            logger.LogInformation("Request failed with {ErrorCount} errors.", errors.Count);
            return Problem(errors);
        }

        logger.LogInformation("Request succeeded.");

        return Results.NoContent();
    }
}
