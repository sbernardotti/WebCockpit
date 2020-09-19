using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace WebCockpit.Infrastructure.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            #region ArgumentException
            if (context.Exception.GetType() == typeof(ArgumentException))
            {
                var exception = (ArgumentException)context.Exception;
                var exceptionInfo = new
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = "Bad request",
                    Detail = exception.Message
                };

                var responseJson = new
                {
                    error = exceptionInfo
                };

                context.Result = new BadRequestObjectResult(responseJson);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            #endregion
        }
    }
}
