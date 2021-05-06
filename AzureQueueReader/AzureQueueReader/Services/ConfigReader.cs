using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureQueueReader
{
    /// <summary>
    /// App configuration value Reader.
    /// </summary>
    class ConfigReader
    {
        /// <summary>
        /// Azure storage connection string.
        /// </summary>
        public static string ConnectionStringAZ
        {
            get
            {
                return ConfigurationManager.AppSettings["connectionstringaz"];
            }
        }
        /// <summary>
        /// Azure storage Queue Name.
        /// </summary>
        public static string QueueName
        {
            get
            {
                return ConfigurationManager.AppSettings["queuenameaz"];
            }
        }
    }
}
