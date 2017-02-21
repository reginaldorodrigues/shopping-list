using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using ShoppingList.Common.Exceptions;
using ShoppingList.Common.Validation;

namespace ShoppingList.Common.WebApi.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ValidationException)
                HandleValidationException(context);
            else if (context.Exception is EntityNotFoundException)
                HandleEntityNotFoundException(context);
            else if (context.Exception is BusinessException)
                HandleBusinessException(context);
            else if (context.Exception is NotImplementedException)
                HandleNotImplementedException(context);
            else if (context.Exception is UnauthorizedAccessException)
                HandleUnauthorizedException(context);
            else
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
        }

        private void HandleUnauthorizedException(HttpActionExecutedContext context)
        {
            var ex = context.Exception as UnauthorizedAccessException;

            context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized, new
            {
                message = ex.Message,
            });
        }

        private void HandleNotImplementedException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        private void HandleEntityNotFoundException(HttpActionExecutedContext context)
        {
            var ex = context.Exception as EntityNotFoundException;

            context.Response = context.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        private void HandleBusinessException(HttpActionExecutedContext context)
        {
            var ex = context.Exception as BusinessException;

            context.Response = context.Request.CreateResponse((HttpStatusCode)420, new
            {
                message = ex.Message,
            });
        }

        private void HandleValidationException(HttpActionExecutedContext context)
        {
            var ex = context.Exception as ValidationException;

            if (ex.Errors.Any())
            {
                var modelState = new ModelStateDictionary();

                foreach (var item in ex.Errors)
                    modelState.AddModelError(item.MemberNames.FirstOrDefault(), item.ErrorMessage);

                context.Response = context.Request.CreateErrorResponse((HttpStatusCode)422, modelState);
            }
            else
            {
                context.Response = context.Request.CreateErrorResponse((HttpStatusCode)422, ex.Message);
            }
        }
    }
}
