using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace WebApp.Services
{
    static class ServiceBus
    {
        public static void AddNServiceBus(this IServiceCollection services)
        {
            var config = new EndpointConfiguration("Sales.API");
            config.UseSerialization<NewtonsoftSerializer>();
            config.UseTransport<LearningTransport>();
            config.SendFailedMessagesTo("error");

            var messageConventions = config.Conventions();
            messageConventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Events"));
            messageConventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages.Commands"));

            var instance = Endpoint.Start(config).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(instance);
        }
    }
}
