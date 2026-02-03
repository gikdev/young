using Backend.Shared.App;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.App;

public static class DependencyInjection {
    public static IServiceCollection AddBackendApp(this IServiceCollection services) {
        services.AddMediatR(options => {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}
