using System;
using System.Linq;
using System.Text;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreSpa.WebApi.Filters
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var messages = context.ModelState.Values
                .Where(x => x.ValidationState == ModelValidationState.Invalid)
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            if (messages.Count == 0)
                return;

            var description = new StringBuilder();
            for (var i = 0; i < messages.Count; i++)
            {
                description.Append(messages[i]);

                if (i == messages.Count - 1) continue;

                description.Append(';');
                description.Append(Environment.NewLine);
            }

            context.Result = new BadRequestObjectResult(new Error(ErrorCode.None, description.ToString()));
        }
    }
}