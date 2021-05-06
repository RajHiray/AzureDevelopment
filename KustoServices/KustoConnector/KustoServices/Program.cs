using Kusto.Data;
using KustoServices.Service;
using System;
using System.Data;

namespace KustoServices
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get service Object.
            KustoConnectionService kustoConnector = KustoConnectionService.GetKustoConnector();
            //Get Connection String.
            var kustoConnectionStringBuilder = kustoConnector.GetKustoConnectionStringBuilder(ConstantAndConfiguration.Cluster, ConstantAndConfiguration.Database, ConstantAndConfiguration.ClientId, ConstantAndConfiguration.ClientSecret,ConstantAndConfiguration.Authority);
            //Execute and get datatable
            DataTable dt = kustoConnector.ExecuteQueryOnKusto(kustoConnectionStringBuilder, ConstantAndConfiguration.Query);
            //Use Dt for Yours use.
            if (dt != null)
            {
                Console.WriteLine("\n[System]: Record selected :"+dt.Rows.Count);
            }
        }
    }
}
