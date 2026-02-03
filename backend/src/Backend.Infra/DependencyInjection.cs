using Backend.App.Common.Interfaces;
using Backend.Infra.Common.Persistence;
using Backend.Infra.Sessions.Persistence;
using Backend.Infra.YsqForms.Persistence;
using Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra;

public static class DependencyInjection {
    public static IServiceCollection AddBackendInfra(this IServiceCollection services, string connStr) {
        services.AddDbContext<BackendDbCtx>((sp, o) => {
            var softDeleteInterceptor = sp.GetRequiredService<SoftDeleteInterceptor>();
            o.AddInterceptors(softDeleteInterceptor);
            o.UseNpgsql(connStr);
        });

        services.AddScoped<IYsqFormRepo, YsqFormRepo>();
        services.AddScoped<ISessionRepo, SessionRepo>();

        return services;
    }
}
