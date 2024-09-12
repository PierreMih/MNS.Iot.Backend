using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MNS.Iot.Backend;
public class HeaderCheckMiddleware : ITransientDependency{
    private readonly RequestDelegate _next;
    private const string RequiredHeaderName = "token";
    private const string RequiredToken = "123token";

    public HeaderCheckMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        Microsoft.Extensions.Primitives.StringValues value;
        var doesValueExist = context.Request.Headers.TryGetValue(RequiredHeaderName, out value);
        if (!doesValueExist || !value.Equals(RequiredToken)) {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync($"missing header field '{RequiredHeaderName}'");
            return;
        }

        await _next(context);
    }
}
