using ApiExceptions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Data.SqlClient;
using System.Net;

namespace ApiExceptions
{
    public static class ApiExceptionsExtensions
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static void ConfigureValidationProblems<TStartUp>(
            this IServiceCollection services,
            string problemTypeUrl = "https://contoso.com/probs/modelvalidation") where TStartUp : class
        {
            services.Configure((ApiBehaviorOptions options) =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = problemTypeUrl,
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };
                    var result = new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<TStartUp>>();
                    logger.LogTrace("Bad Request {@data}", result);
                    return result;
                };
            });
        }

        public static void UseGlobalExceptionHandler<TStartUp>(this IApplicationBuilder app) where TStartUp : class
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/problem+json";
                    var logger = app.ApplicationServices.GetRequiredService<ILogger<TStartUp>>();
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        switch (contextFeature.Error)
                        {
                            case BadRequestException badRequestException:
                                logger.LogError(badRequestException, "Bad Request Exception");
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                await context.Response.WriteAsync(Serialize(
                                    new ValidationProblemDetails(badRequestException.ModelState)
                                    {
                                        Detail = badRequestException.Message
                                    }));
                                break;

                            case RequestBaseException requestBaseException:
                                logger.LogError(requestBaseException, "Request Exception Type={type}",
                                    requestBaseException.GetType().Name);
                                context.Response.StatusCode = requestBaseException.HttpStatusCode;
                                await context.Response.WriteAsync(Serialize(
                                    new ProblemDetails()
                                    {
                                        Status = requestBaseException.HttpStatusCode,
                                        Detail = requestBaseException.Message
                                    }));
                                break;

                            case Exception exception
                                when exception.InnerException?.InnerException is SqlException sqlException &&
                                     sqlException.Number == 547:
                                logger.LogError(exception,
                                    $"Dependent entities exists - This entity cannot be deleted");
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                await context.Response.WriteAsync(Serialize(
                                    new ProblemDetails()
                                    {
                                        Detail = "Cannot delete entity that has dependent items",
                                        Status = (int)HttpStatusCode.BadRequest,
                                        Extensions =
                                        {
                                            {"Reason", "Cannot delete category because it has dependent items"}
                                        }
                                    }));
                                break;

                            default:
                                logger.LogError(contextFeature.Error, "Something went wrong");
                                await context.Response.WriteAsync(Serialize(
                                    new ProblemDetails()
                                    {
                                        Status = (int)HttpStatusCode.InternalServerError,
                                        Detail = "Something went wrong at our side!"
                                    }));
                                break;
                        }
                    }
                });
            });
        }

        private static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }
    }
}
