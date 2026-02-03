using Backend.App;
using Backend.Infra;
using Backend.Shared.Api;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Api;

public static class Extensions {
    public static IServiceCollection AddBackend(this IServiceCollection services, string connStr) {
        services.AddBackendApp();
        services.AddBackendInfra(connStr);
        services.AddValidatorsFromAssemblyContaining(typeof(Extensions));

        return services;
    }

    public static IEndpointRouteBuilder MapBackend(this IEndpointRouteBuilder app) {
        app.MapApiEndpoints(typeof(Extensions));

        return app;
    }
}
