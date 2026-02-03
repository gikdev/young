using Backend.Shared.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Shared;

public static class DependencyInjection {
    public static IServiceCollection AddSharedServices(this IServiceCollection services) {
        services.AddScoped<SoftDeleteInterceptor>();

        return services;
    }
}
