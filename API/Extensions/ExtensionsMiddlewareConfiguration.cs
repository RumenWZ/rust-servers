﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace API.Extensions
{
    public static class ExtensionsMiddlewareConfiguration
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            await context.Response.WriteAsync(ex.Error.Message);
                        }
                    });
            });
        }
    }
}
