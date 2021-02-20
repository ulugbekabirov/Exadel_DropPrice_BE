using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
