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

internal class GetYsqFormByIdEndpoint : EndpointBase {
    public override ApiRoute Route => ApiEndpoints.YsqForms.GetYsqFormById;

    public override void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapMethods(Route.Path, Route.Methods, Handle)
            .WithName(Route.Name)
            .WithSummary(Route.Summary)
            .WithDescription(Route.Description)
            .WithTags(Route.Tag)
            .Produces<YsqFormFullResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ILogger<GetYsqFormByIdEndpoint> logger,
        [FromServices] ISender                         mediator,
        [FromRoute]    Guid                            ysqFormId
    ) {
        logger.LogDebug("Request received with {#YsqFormId}.", ysqFormId);

        var result = await mediator.Send(Mappings.CreateGetYsqFormByIdQuery(ysqFormId));

        if (result.IsError) {
            var errors = result.Errors;
            logger.LogInformation("Request failed with {ErrorCount} errors.", errors.Count);
            return Problem(errors);
        }

        var ysqForm = result.Value;

        logger.LogInformation("Request succeeded #{YsqFormId}", ysqFormId);

        return Results.Ok(ysqForm.MapToFullResponse());
    }
}
