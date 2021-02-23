using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Middleware.Localization
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
            var language = GetFirstTwoLettersOfAcceptLanguageHeader(acceptedLanguages);

            if (Cultures.SupportedCultures.Contains(language))
            {
                SetCultureToThread(language);
            }
            else
            {
                SetCultureToThread(Cultures.DefaultCulture);
            }

            await _next.Invoke(context);
        }

        private static void SetCultureToThread(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        private static string GetFirstTwoLettersOfAcceptLanguageHeader(string acceptedLanguages)
        {
            return acceptedLanguages.Split(new char[] { '-', ',' }).FirstOrDefault();
        }
    }
}
