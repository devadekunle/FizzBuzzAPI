using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzAPI.Middleware
{
    public static class GlobalExceptionHandler
    {
        
            public static void ConfigureExceptionHandler(this IApplicationBuilder app)
            {
                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            
                            await context.Response.WriteAsync(new ApiResponse<string>(default,code: StatusCodes.Status400BadRequest, errorMessage: contextFeature.Error.Message).ToString());
                        }
                    });
                });
            }
        
    }
}
