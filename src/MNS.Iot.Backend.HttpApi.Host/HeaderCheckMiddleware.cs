using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MNS.Iot.Backend;
public class HeaderCheckMiddleware : ITransientDependency{
    private readonly RequestDelegate _next;
    private const string RequiredHeaderName = "token";
    private const string RequiredToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

    public HeaderCheckMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
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
