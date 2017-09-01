using NServiceBus;
using Shipping.Messages.Commands;
using System.Threading.Tasks;

namespace Shipping.Services
{
    class CleanupCartHandler : IHandleMessages<CleanupCart>
    {
        public Task Handle(CleanupCart message, IMessageHandlerContext context)
        {
            //do whatever is required to clean up the cart
            return Task.CompletedTask;
        }
    }
}
