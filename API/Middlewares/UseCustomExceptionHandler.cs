using Core.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseUserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c =>
            {
                c.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var excepfeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statuscode = excepfeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statuscode;
                    var response = CResponseDto<bool>.Fail(statuscode, excepfeature.Error.Message);
                    await context.Response.WriteAsJsonAsync(response);
                });
            });
        }
    }
}
