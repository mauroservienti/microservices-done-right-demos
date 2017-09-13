using Marketing.Messages.Events;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Marketing.Services
{
    class InactiveCartWipedHandler : IHandleMessages<InactiveCartWiped>
    {
        public Task Handle(InactiveCartWiped message, IMessageHandlerContext context)
        {
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Cart {message.CartId} wiped, another lost customer :-(");

            Console.ForegroundColor = backup;

            return Task.CompletedTask;
        }
    }
}
