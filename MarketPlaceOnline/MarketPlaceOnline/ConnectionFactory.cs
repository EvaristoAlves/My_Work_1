using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceOnline
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                "AuthType= OAuth;" +
                "Username=EvaristoAlves@TreinamentoDynamics2022.onmicrosoft.com;" +
                "Password=P@ssword#;" +
                "Url=https://orgc7aca8a9.crm2.dynamics.com/ ;" +
                "AppId=ae54efe1-1540-456e-9fbc-ca228ce68145;" +
                "RedirectUri= app://58145B91-0C36-4500-8554-080854F2AC97";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
