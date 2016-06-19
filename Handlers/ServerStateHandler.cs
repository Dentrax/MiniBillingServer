
using System.Net;
using MiniBillingServer.Http;

namespace MiniBillingServer.Handlers
{
    class ServerStateHandler : FilteredHttpHandler
    {
        public override bool Handle(HttpListenerContext context)
        {
<<<<<<< HEAD
            #region SecurityCheck
            IPAddress clientIP = context.Request.RemoteEndPoint.Address;

            List<string> HostIP = new List<string>();
            foreach (string AuthorizedHost in this.m_securityConfig.Allowed_Hosts)
            {
                HostIP.Add(Dns.GetHostAddresses(AuthorizedHost)[0].ToString());
            }

            if (this.m_securityConfig.Allowed_IPs.Contains(clientIP) || HostIP.Contains(clientIP.ToString())) { } else { return false; }

            #endregion
=======
>>>>>>> new_access_filter
            // Validate Handler
            if (context.Request.Url.LocalPath.ToLower() != "/billing_serverstate.asp")
            {
                return false;
            }

            // Security check
            base.Handle(context);
            

            // Build response
            SendResult(context.Response, "1");

            return true;
        }
    }
}
