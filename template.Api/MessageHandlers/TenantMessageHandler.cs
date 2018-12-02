using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace template.Api.MessageHandlers
{
    public class TenantMessageHandler : DelegatingHandler
    {
        private readonly IServiceProvider _provider;

        public TenantMessageHandler(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContextAccessor = _provider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
            var tenantId = httpContextAccessor.HttpContext.Items["x-tenant-id"] as string;

            request.Headers.Add("x-tenant-id", tenantId);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
