using Sales.Data.Context;
using Sales.Data.Models;
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

            using (var db = new SalesContext())
            {
                var cart = db.ShoppingCarts
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

                cart.Items.Add(new ShoppingCartItem()
                {
                    CartId = cartId,
                    RequestId = Request.Headers.GetValues("request-id").Single(),
                    ProductId = productId,
                    ProductPrice = product.Price,
                    Quantity = quantity
                });

                await db.SaveChangesAsync();
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
