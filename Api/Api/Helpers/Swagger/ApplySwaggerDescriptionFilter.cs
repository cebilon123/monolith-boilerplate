using System.Linq;
using Api.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Helpers.Swagger
{
    public class ApplySwaggerDescriptionFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.CustomAttributes()
                .FirstOrDefault(a => a.GetType() == typeof(SwaggerDescriptionAttribute)) is SwaggerDescriptionAttribute attr)
            {
                operation.Description = attr.Description;
            }
        }
    }
}