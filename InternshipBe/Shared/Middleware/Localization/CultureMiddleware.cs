using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Localization
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var acceptedLanguages = context.Request.Headers["Accept-Language"].ToString();
            var language = acceptedLanguages.Split(',').FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(language))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            }

            await _next.Invoke(context);
        }
    }
}
