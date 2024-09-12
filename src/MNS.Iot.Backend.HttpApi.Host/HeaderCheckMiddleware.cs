using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MNS.Iot.Backend;
public class HeaderCheckMiddleware : ITransientDependency{
    private readonly RequestDelegate _next;
    private const string RequiredHeaderName = "Authorization";
    private const string RequiredToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

    public HeaderCheckMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        var path = context.Request.Path.Value;
        if (path.StartsWith("/swagger") || path.StartsWith("/api-docs"))
        {
            await _next(context);
            return;
        }
        Microsoft.Extensions.Primitives.StringValues value;
        var doesValueExist = context.Request.Headers.TryGetValue(RequiredHeaderName, out value);
        if (!doesValueExist || !value.Equals(RequiredToken)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync($"Unauthorized");
            // await context.Response.WriteAsync($"missing header field '{RequiredHeaderName}'");
            return;
        }

        await _next(context);
    }
}
