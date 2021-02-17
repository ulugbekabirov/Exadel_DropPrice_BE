using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shared.Infrastructure.Filters
{
    public class ValidateModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                actionContext.HttpContext.Response.StatusCode = 400;

                actionContext.Result = new ContentResult()
                {
                    Content = string.Join(Environment.NewLine, modelState.Values.SelectMany(v => v.Errors.Select(e=>e.ErrorMessage)))
                };

                return;
            }

        }
    }
}


