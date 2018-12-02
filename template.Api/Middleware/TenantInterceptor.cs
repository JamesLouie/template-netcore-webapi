using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace template.Api.Middleware
{
    public class TenantInterceptor
    {
        private const string TenantHeader = "x-tenant-id";
        private readonly RequestDelegate _next;

        public TenantInterceptor(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue(TenantHeader, out var tenantHeaders))
            {
                var tenantId = tenantHeaders.First();
                httpContext.Items[TenantHeader] = tenantId;
            }

            await _next(httpContext);
        }
    }
}
