using Microsoft.Extensions.DependencyInjection;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Interfaces.Repositories;
using Vasis.MDFe.Core.Interfaces.Services;
using Vasis.MDFe.Infrastructure.External.Zeus;
using Vasis.MDFe.Infrastructure.Repositories;
using Vasis.MDFe.Infrastructure.Security;

namespace Vasis.MDFe.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IMDFeRepository, InMemoryMDFeRepository>();

        // External Services
        services.AddScoped<IZeusWrapper, ZeusWrapper>();

        // Security Services
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}