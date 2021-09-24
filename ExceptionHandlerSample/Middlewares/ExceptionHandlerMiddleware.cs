using ExceptionHandlerSample.Business;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ExceptionHandlerSample.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //RFC7807 - Problem Details for HTTP APIs
            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.HttpContext.Request.Path
            };

            if (exception is WeatherForecastBusinessException forecastBusinessException)
            {
                problemDetails.Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503";
                problemDetails.Title = "Exception thrown by the Business Layer";
                problemDetails.Status = 503;
                problemDetails.Detail = forecastBusinessException.Message;
            }
            else
            {
                problemDetails.Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500";
                problemDetails.Title = exception.Message;
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                if (_env.IsDevelopment())
                    problemDetails.Detail = JsonConvert.SerializeObject(exception);
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
