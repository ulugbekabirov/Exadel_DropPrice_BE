using Microsoft.AspNetCore.Builder;

namespace Shared.Middleware.Localization
{
    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
