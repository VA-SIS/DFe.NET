using Microsoft.Extensions.DependencyInjection;
using Vasis.MDFe.Application.Mappings;
using Vasis.MDFe.Application.Services.Auth;
using Vasis.MDFe.Application.Services.Document;

namespace Vasis.MDFe.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

        // Application Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMDFeDocumentService, MDFeDocumentService>();

        return services;
    }
}