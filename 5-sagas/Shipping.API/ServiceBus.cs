using NServiceBus;

namespace Shipping.API
{
    class ServiceBus
    {
        public static IEndpointInstance Instance { get; private set; }

        public static void Start()
        {
            var config = new EndpointConfiguration("Shipping.API");
            config.UseSerialization<NewtonsoftSerializer>();
            config.UseTransport<LearningTransport>();
            config.SendFailedMessagesTo("error");

            var messageConventions = config.Conventions();
            messageConventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Events"));
            messageConventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Commands"));

            Instance = Endpoint.Start(config).GetAwaiter().GetResult();
        }
    }
}
