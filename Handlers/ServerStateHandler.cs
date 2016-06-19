using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

namespace MiniBillingServer.Handlers
{
    class ServerStateHandler : Http.IHttpHandler
    {
        public override bool Handle(HttpListenerContext context)
        {
            #region SecurityCheck
            IPAddress clientIP = context.Request.RemoteEndPoint.Address;

            List<string> HostIP = new List<string>();
            foreach (string AuthorizedHost in this.m_securityConfig.Allowed_Hosts)
            {
                HostIP.Add(Dns.GetHostAddresses(AuthorizedHost)[0].ToString());
            }

            if (this.m_securityConfig.Allowed_IPs.Contains(clientIP) || HostIP.Contains(clientIP.ToString())) { } else { return false; }

            #endregion
            // Validate Handler
            if (context.Request.Url.LocalPath.ToLower() != "/billing_serverstate.asp")
            {
                return false;
            }

            // Build response
            SendResult(context.Response, "1");

            return true;
        }
    }
}
