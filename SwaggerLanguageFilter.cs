using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fathy.Swagger;

public class SwaggerLanguageFilter(IServiceProvider serviceProvider) : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new()
        {
            Name = "Accept-Language",
            Description = "Supported Languages",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new()
            {
                Type = "string",
                Enum = (serviceProvider.GetService(typeof(IOptions<RequestLocalizationOptions>)) as
                        IOptions<RequestLocalizationOptions>)?
                    .Value.SupportedCultures?.Select(culture => new OpenApiString(culture.TwoLetterISOLanguageName))
                    .ToList<IOpenApiAny>()
            }
        });
    }
}