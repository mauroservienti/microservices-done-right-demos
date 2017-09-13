using Marketing.Messages.Events;
using NServiceBus;
using Shipping.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.API.Handlers
{
    class InactiveCartWipedHandler : IHandleMessages<InactiveCartWiped>
    {
        public async Task Handle(InactiveCartWiped message, IMessageHandlerContext context)
        {
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Ready to wipe cart {message.CartId}...");

            using (var db = new ShippingContext())
            {
                var cartItems = db.ShoppingCartItems.Where(i => i.CartId == message.CartId);
                foreach (var item in cartItems)
                {
                    db.ShoppingCartItems.Remove(item);
                }
                await db.SaveChangesAsync();
            }

            Console.WriteLine($"Cart {message.CartId} wiped.");

            Console.ForegroundColor = backup;
        }
    }
}
