using Marketing.Messages.Events;
using NServiceBus;
using Sales.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Handlers
{
    class InactiveCartWipedHandler : IHandleMessages<InactiveCartWiped>
    {
        public async Task Handle(InactiveCartWiped message, IMessageHandlerContext context)
        {
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Ready to wipe cart {message.CartId}...");

            using (var db = new SalesContext())
            {
                var cart = db.ShoppingCarts
                    .Where(c => c.Id == message.CartId)
                    .Single();

                db.ShoppingCarts.Remove(cart);

                await db.SaveChangesAsync();
            }

            Console.WriteLine($"Cart {message.CartId} wiped.");

            Console.ForegroundColor = backup;
        }
    }
}
