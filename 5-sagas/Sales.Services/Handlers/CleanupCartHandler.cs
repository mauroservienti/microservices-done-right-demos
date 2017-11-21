using NServiceBus;
using Sales.Data.Context;
using Sales.Messages.Commands;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Handlers
{
    class CleanupCartHandler : IHandleMessages<CleanupCart>
    {
        public async Task Handle(CleanupCart message, IMessageHandlerContext context)
        {
            using (var db = new SalesContext())
            {
                var cart = db.ShoppingCarts
                    .Include(c => c.Items)
                    .Where(o => o.Id == message.CartId)
                    .SingleOrDefault();

                if (cart != null)
                {
                    var itemToRemove = cart.Items.SingleOrDefault(item => item.RequestId == message.RequestId);
                    if (itemToRemove != null)
                    {
                        cart.Items.Remove(itemToRemove);
                        await db.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
