using System.Collections.Generic;
using System.Net;

namespace MiniBillingServer.Http
{
    abstract class FilteredHttpHandler : IHttpHandler
    {
        public override bool Handle(System.Net.HttpListenerContext context)
        {
            string clientIP = context.Request.RemoteEndPoint.Address.ToString();

            List<string> HostIP = new List<string>();
            foreach (string AuthorizedHost in IO.Config.cfg.Allowed_Hosts)
            {
                HostIP.Add(Dns.GetHostAddresses(AuthorizedHost)[0].ToString());
            }

            if (!(IO.Config.cfg.Allowed_IPs.Contains(clientIP) || HostIP.Contains(clientIP)))
            {
                throw new AccessDeniedException("Access to the resource was denied", context);
            }

            return true;
        }
    }
}
