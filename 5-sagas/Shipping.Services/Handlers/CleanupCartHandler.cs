using NServiceBus;
using Shipping.Data.Context;
using Shipping.Messages.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.Services.Handlers
{
    class CleanupCartHandler : IHandleMessages<CleanupCart>
    {
        public async Task Handle(CleanupCart message, IMessageHandlerContext context)
        {
            using (var db = new ShippingContext())
            {
                var shoppingCartItem = db.ShoppingCartItems.SingleOrDefault(item => item.RequestId == message.RequestId);
                if (shoppingCartItem != null)
                {
                    db.ShoppingCartItems.Remove(shoppingCartItem);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
