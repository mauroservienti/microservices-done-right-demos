using NServiceBus;
using Sales.Messages.Events;
using System;
using System.Threading.Tasks;

namespace Marketing.Services
{
    class CartGotStaleHandler : IHandleMessages<CartGotStale>
    {
        public Task Handle(CartGotStale message, IMessageHandlerContext context)
        {
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Cart {message.CartId} is stale, let's annoy the user with an email :-)");

            Console.ForegroundColor = backup;

            return Task.CompletedTask;
        }
    }
}
