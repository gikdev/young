using Backend.Api.Contracts.YsqForms;
using Backend.Shared.Api;
using Backend.Shared.Api.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Backend.Api.YsqForms.Endpoints;

internal class ListYsqFormsEndpoint : EndpointBase {
    public override ApiRoute Route => ApiEndpoints.YsqForms.ListYsqForms;

    public override void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapMethods(Route.Path, Route.Methods, Handle)
            .WithName(Route.Name)
            .WithSummary(Route.Summary)
            .WithDescription(Route.Description)
            .WithTags(Route.Tag)
            .Produces<YsqFormSummariesResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ILogger<ListYsqFormsEndpoint> logger,
        [FromServices] ISender                       mediator
    ) {
        logger.LogDebug("Request received.");

        var result = await mediator.Send(Mappings.CreateListYsqFormsQuery());

        if (result.IsError) {
            var errors = result.Errors;
            logger.LogInformation("Request failed with {ErrorCount} errors.", errors.Count);
            return Problem(errors);
        }

        var ysqForms = result.Value;

        logger.LogInformation("Request succeeded.");

        return Results.Ok(ysqForms.MapToSummariesResponse());
    }
}
