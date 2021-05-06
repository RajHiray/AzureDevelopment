using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureQueueReader.Services
{
    /// <summary>
    /// Provide Services for Queue Storage Azure.
    /// </summary>
    class QueueServices
    {
        /// <summary>
        /// Get latest Message from Queue.       
        /// </summary>
        /// <param name="storageConnectionStr">Storage Connection Str</param>
        /// <param name="queueName">Queue Name</param>
        /// <returns>Message on Queue</returns>
        public string GetMessage(string storageConnectionStr,string queueName)
        {
            string result = string.Empty;
            if(!string.IsNullOrEmpty(storageConnectionStr)&& !string.IsNullOrEmpty(queueName))
            {
                try
                {
                    // Parse the connection string and return a reference to the storage account.
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionStr);
                    // Create the queue client
                    CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                    // Retrieve a reference to a queue
                    CloudQueue queue = queueClient.GetQueueReference(queueName);
                    // Peek at the next message
                    CloudQueueMessage peekedMessage = queue.PeekMessage();
                    if (peekedMessage != null)
                        result = peekedMessage.AsString;
                }
                catch (Exception ex)
                {
                    //Handling and Logging.
                }
            }
            return result;
        }
    }
}
