using Microsoft.AspNetCore.Builder;

namespace Shared.Localization
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
