using Kusto.Data;
using Kusto.Data.Net.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KustoServices.Service
{
    class KustoConnectionService
    {
        public static KustoConnectionService kustoConnector = null;
        /// <summary>
        /// Singleton Pattern for Service.
        /// </summary>
        private KustoConnectionService()
        {
            Console.WriteLine("\n[System]: In Kusto Connector Construtor ");
        }
        /// <summary>
        /// Get instance using static entry.
        /// </summary>
        /// <returns></returns>
        public static KustoConnectionService GetKustoConnector()
        {
            Console.WriteLine("\n[System]: getting kusto service instance");
            if (kustoConnector == null)
                kustoConnector = new KustoConnectionService();
            return kustoConnector;
        }
        /// <summary>
        /// Get kusto query record into Datatable.
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable ExecuteQueryOnKusto(KustoConnectionStringBuilder kustoConnectionStringBuilder, string query)
        {
            Console.WriteLine("\n[System]: In Kusto Execute Query to get DT");
            DataTable dt = new DataTable();

            if (kustoConnectionStringBuilder != null && !string.IsNullOrWhiteSpace(query))
            {
                try
                {
                    var clients = KustoClientFactory.CreateCslQueryProvider(kustoConnectionStringBuilder);
                    using (var record = clients.ExecuteQuery(query))
                    {
                        if (record != null)
                        {
                            dt.Load(record);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n[System]: Exception :" + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Get Kusto connection string.
        /// </summary>
        /// <param name="clusteruri">clusteruri</param>
        /// <param name="database">database</param>
        /// <param name="appId">appId</param>
        /// <param name="appKey">appKey</param>
        /// <param name="authority">authorityuri</param>
        /// <returns>Kusto Connection String</returns>
        public KustoConnectionStringBuilder GetKustoConnectionStringBuilder(string clusteruri, string database, string appId, string appKey, string authority)
        {
            Console.WriteLine("\n[System]: In Kusto Connection String Builder");
            KustoConnectionStringBuilder kcsb = null;
            if (!string.IsNullOrWhiteSpace(clusteruri) && !string.IsNullOrWhiteSpace(database) && !string.IsNullOrWhiteSpace(appId) && !string.IsNullOrWhiteSpace(appKey))
            {
                kcsb = new KustoConnectionStringBuilder(clusteruri)
                {
                    FederatedSecurity = true,
                    InitialCatalog = database,
                    ApplicationClientId = appId,
                    ApplicationKey = appKey,
                    Authority = authority
                };
            }
            return kcsb;
        }
    }
}
