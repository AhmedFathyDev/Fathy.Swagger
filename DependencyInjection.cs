using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Fathy.Swagger;

public static class DependencyInjection
{
    public static void AddSwaggerService(this IServiceCollection services, OpenApiInfo openApiInfo)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(swaggerGenOption =>
        {
            swaggerGenOption.OperationFilter<SwaggerLanguageFilter>();
            swaggerGenOption.OperationFilter<SwaggerQueryParameterFilter>();

            swaggerGenOption.SwaggerDoc(openApiInfo.Version, openApiInfo);

            swaggerGenOption.AddSecurityDefinition("Bearer", new()
            {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                Description = "Please enter JWT Bearer token **only**.",
            });

            swaggerGenOption.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}