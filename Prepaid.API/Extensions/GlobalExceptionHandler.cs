using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Prepaid.API.Extensions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetail = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "Something went wrong, please contact your administrator"
            };
            httpContext.Response.StatusCode = problemDetail.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetail, cancellationToken);
            return true;
        }
    }
}
