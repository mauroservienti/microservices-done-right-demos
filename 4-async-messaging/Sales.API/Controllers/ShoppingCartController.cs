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

                var product = db.ProductsPrices
                    .Where(o => o.ProductId == productId)
                    .Single();

                var cartItem = cart.Items.SingleOrDefault(item => item.ProductId == productId);
                if (cartItem == null)
                {
                    cartItem = new ShoppingCartItem()
                    {
                        CartId = cartId,
                        ProductId = productId,
                        ProductPrice = product.Price
                    };
                    cart.Items.Add(cartItem);
                }

                cartItem.Quantity++;

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
                var cart = db.ShoppingCarts
                    .Include(c => c.Items)
                    .Where(o => o.Id == id)
                    .SingleOrDefault();

                return cart;
            }
        }
    }
}
