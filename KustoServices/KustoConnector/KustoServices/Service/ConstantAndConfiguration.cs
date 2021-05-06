using System;
using System.Collections.Generic;
using System.Text;

namespace KustoServices.Service
{
    class ConstantAndConfiguration
    {
        public const string AadInstance = "Instance URI";
        public const string TenantId = "Tenant ID";
        public const string Authority = AadInstance + TenantId;
        public const string ClientId = "AAD App ID";
        public const string ClientSecret = "AAD App Secret";
        public const string Cluster = "Cluster URI";           //https://<clustername>.kusto.windows.net/
        public const string Database = "Cluster Database Name";
        public const string Query = "Kusto Query";
    }
}
