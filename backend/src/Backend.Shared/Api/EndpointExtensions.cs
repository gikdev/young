using Microsoft.AspNetCore.Routing;

namespace Backend.Shared.Api;

public static class EndpointExtensions {
    public static IEndpointRouteBuilder MapApiEndpoints<TMarker>(this IEndpointRouteBuilder app) {
        var typeMarker = typeof(TMarker);

        app.MapApiEndpoints(typeMarker);

        return app;
    }

    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app, Type typeMarker) {
        var endpointTypes = typeMarker.Assembly.DefinedTypes
            .Where(x =>
                !x.IsAbstract  &&
                !x.IsInterface &&
                typeof(EndpointBase).IsAssignableFrom(x)
            );

        foreach (var endpointType in endpointTypes) {
            var endpoint = Activator.CreateInstance(endpointType) as EndpointBase;
            endpoint?.MapEndpoint(app);
        }

        return app;
    }
}
