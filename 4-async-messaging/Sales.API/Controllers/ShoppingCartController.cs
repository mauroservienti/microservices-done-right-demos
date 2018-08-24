using NServiceBus;
using Sales.Data.Context;
using Sales.Data.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sales.API.Controllers
{
    public class ShoppingCartController : ApiController
    {
        [HttpPost]
        [Route("api/shopping-cart")]
        public async Task<IHttpActionResult> AddToCart(dynamic data)
        {
            var cartId = (int)data.CartId;
            var productId = (int)data.ProductId;
            var quantity = (int)data.Quantity;
            var requestId = Request.Headers.GetValues("request-id").Single();

            using (var db = new SalesContext())
            {
                var cart = db.ShoppingCarts
                    .Include(c => c.Items)
                    .Where(o => o.Id == cartId)
                    .SingleOrDefault();
                if (cart == null)
                {
                    cart = new ShoppingCart()
                    {
                        Id = data.CartId
                    };
                    db.ShoppingCarts.Add(cart);
                }

                var alreadyAdded = cart.Items.Any(item => item.RequestId == requestId);
                if (!alreadyAdded)
                {
                    var product = db.ProductsPrices
                        .Where(o => o.ProductId == productId)
                        .Single();

                    cart.Items.Add(new ShoppingCartItem()
                    {
                        CartId = cartId,
                        RequestId = requestId,
                        ProductId = productId,
                        ProductPrice = product.Price,
                        Quantity = quantity
                    });
                }

                await db.SaveChangesAsync();
            }

            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/shopping-cart/{id}")]
        public dynamic GetCart(int id)
        {
            using (var db = new SalesContext())
            {
                var cartItems = db.ShoppingCarts
                    .Include(c => c.Items)
                    .Where(o => o.Id == id)
                    .SelectMany(cart => cart.Items)
                    .ToArray()
                    .GroupBy(cartItem => cartItem.ProductId)
                    .Select(group => new
                    {
                        ProductId = group.Key,
                        Quantity = group.Sum(cartItem => cartItem.Quantity),
                        ProductPrice = group.FirstOrDefault()?.ProductPrice
                    })
                    .ToArray();

                return new
                {
                    CartId = id,
                    Items = cartItems
                };
            }
        }
    }
}
