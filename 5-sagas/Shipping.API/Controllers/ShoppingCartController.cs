using Shipping.Data.Context;
using Shipping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shipping.API.Controllers
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

            using (var db = new ShippingContext())
            {
                var shippingDetails = db.ProductsShippingDetails
                    .Where(o => o.ProductId == productId)
                    .Single();

                var cartItem = db.ShoppingCartItems
                    .Where(o => o.ProductId == productId)
                    .SingleOrDefault();
                if (cartItem == null)
                {
                    cartItem = new ShoppingCartItem()
                    {
                        CartId = cartId,
                        ProductId = productId,
                        ShippingCost = shippingDetails.Cost,
                        FreeShippingEligible = shippingDetails.FreeShippingEligible
                    };
                    db.ShoppingCartItems.Add(cartItem);
                }

                cartItem.Quantity += quantity;
                if (!cartItem.FreeShippingEligible && cartItem.Quantity > 1)
                {
                    var cost = cartItem.ShippingCost;
                    var qty = cartItem.Quantity;
                    cartItem.ShippingCost += (cost * qty) / 100;
                }

                await db.SaveChangesAsync();
            }
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/shopping-cart/products/{ids}")]
        public IEnumerable<dynamic> GetCart(string ids)
        {
            using (var db = new ShippingContext())
            {
                var productIds = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
                var items = db.ShoppingCartItems
                    .Where(item => productIds.Any(id => id == item.ProductId))
                    .ToArray();

                return items;
            }
        }
    }
}
