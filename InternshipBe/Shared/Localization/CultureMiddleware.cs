using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
            var lang = context.Request.Headers["Accept-Language"].ToString();
            if (!string.IsNullOrWhiteSpace(lang))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
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
