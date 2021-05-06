using System;
using AzureQueueReader.Services;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace AzureQueueReader
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueServices queueServices = new QueueServices();
            
            //Get message from Queue.
            string message= queueServices.GetMessage(ConfigReader.ConnectionStringAZ, ConfigReader.QueueName);
            if(string.IsNullOrEmpty(message))
                Console.WriteLine(message);
            else
                Console.WriteLine("Message Not Found");
            Console.ReadKey();
        }
    }
}
