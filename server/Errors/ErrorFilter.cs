using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExerciseServices.Errors
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public class ErrorFilter : ExceptionFilterAttribute
  {
    public override async void OnException(ExceptionContext context)
    {
      byte[] body = null;
      var statusCode = HttpStatusCode.InternalServerError;

      if (context.Exception is IExerciseAppError)
      {
        var exception = (IExerciseAppError)context.Exception;
        statusCode = exception.Status;
        body = exception.ToJsonBytes();
      }

      context.HttpContext.Response.ContentType = "application/json";
      context.HttpContext.Response.StatusCode = (int) statusCode;
      if (body != null) await context.HttpContext.Response.Body.WriteAsync(body, 0, body.Length);
    }
  }
}