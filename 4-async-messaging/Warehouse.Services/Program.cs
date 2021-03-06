﻿using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Warehouse.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointName = "Warehouse.Services";
            Console.Title = endpointName;
            MainAsync(endpointName).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string endpointName)
        {
            var config = new EndpointConfiguration(endpointName);
            //endpointConfiguration.UsePersistence<LearningPersistence>();
            config.UseTransport<LearningTransport>();
            config.UseSerialization<NewtonsoftSerializer>();
            config.SendFailedMessagesTo("error");

            var messageConventions = config.Conventions();
            messageConventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Events"));
            messageConventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Commands"));

            var endpointInstance = await Endpoint.Start(config)
                .ConfigureAwait(false);
            try
            {
                Console.WriteLine($"\r\n{endpointName} bus created and configured; press any key to stop program\r\n");
                Console.ReadKey();
            }
            finally
            {
                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }
        }
    }
}
