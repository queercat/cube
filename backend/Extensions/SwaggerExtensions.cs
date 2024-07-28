namespace backend.Extensions;

using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

public static class SwaggerExtensions
{
    public static void SaveSwaggerJson(this IServiceProvider provider)
    {
        var sw = provider.GetRequiredService<ISwaggerProvider>();
        var doc = sw.GetSwagger("v1", null, "/");
        var swaggerFile = doc.SerializeAsJson(Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
        
        File.WriteAllText("api.json", swaggerFile);
    }
}