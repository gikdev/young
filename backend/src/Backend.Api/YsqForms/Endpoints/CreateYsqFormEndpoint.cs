using Backend.Api.Contracts.YsqForms;
using Backend.Shared.Api;
using Backend.Shared.Api.Endpoints;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Backend.Api.YsqForms.Endpoints;

internal class CreateYsqFormEndpoint : EndpointBase {
    public override ApiRoute Route => ApiEndpoints.YsqForms.CreateYsqForm;

    public override void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapMethods(Route.Path, Route.Methods, Handle)
            .WithName(Route.Name)
            .WithSummary(Route.Summary)
            .WithTags(Route.Tag)
            .WithDescription(Route.Description)
            .Accepts<CreateYsqFormRequest>("application/json")
            .Produces(StatusCodes.Status201Created);
    }

    private static async Task<IResult> Handle(
        [FromServices] ILogger<CreateYsqFormEndpoint>   logger,
        [FromServices] ISender                          mediator,
        [FromServices] IValidator<CreateYsqFormRequest> validator,
        [FromBody]     CreateYsqFormRequest             request
    ) {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

        logger.LogDebug("Request received with {@Request}.", request);

        var commandResult = request.MapToCommand();

        if (commandResult.IsError) {
            var errors = commandResult.Errors;
            logger.LogInformation("Request failed with {ErrorCount} errors.", errors.Count);
            return Problem(errors);
        }

        var command = commandResult.Value;

        var ysqFormResult = await mediator.Send(command);

        if (ysqFormResult.IsError) {
            var errors = ysqFormResult.Errors;
            logger.LogInformation("Request failed with {ErrorCount} errors.", errors.Count);
            return Problem(errors);
        }

        var ysqForm = ysqFormResult.Value;

        logger.LogInformation("Request succeeded #{YsqFormId}", ysqForm.Id);

        return Results.Created();
    }
}
