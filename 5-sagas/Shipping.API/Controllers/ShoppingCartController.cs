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
            var requestId = Request.Headers.GetValues("request-id").Single();

            using (var db = new ShippingContext())
            {
                var alreadyAdded = db.ShoppingCartItems.Any(item => item.RequestId == requestId);
                if (!alreadyAdded)
                {
                    var shippingDetails = db.ProductsShippingDetails
                        .Where(o => o.ProductId == productId)
                        .Single();

                    var cartItem = new ShoppingCartItem()
                    {
                        CartId = cartId,
                        RequestId = Request.Headers.GetValues("request-id").Single(),
                        ProductId = productId,
                        Quantity = quantity,
                        ItemShippingCost = shippingDetails.Cost,
                        FreeShippingEligible = shippingDetails.FreeShippingEligible
                    };

                    db.ShoppingCartItems.Add(cartItem);
                    await db.SaveChangesAsync();
                }
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

                var cartItems = db.ShoppingCartItems
                    .Where(item => productIds.Any(id => id == item.ProductId))
                    .ToArray()
                    .GroupBy(cartItem => cartItem.ProductId)
                    .Select(group =>
                    {
                        var cartId = group.First().CartId;
                        var freeShippingEligible = group.First().FreeShippingEligible;
                        var quantity = group.Sum(cartItem => cartItem.Quantity);
                        var itemShippingCost = group.First().ItemShippingCost;

                        var shippingCost = itemShippingCost;
                        if (quantity > 1)
                        {
                            shippingCost = itemShippingCost + (((itemShippingCost * 10) / 100) * quantity);
                        }

                        return new
                        {
                            ProductId = group.Key,
                            CartId = cartId,
                            FreeShippingEligible = freeShippingEligible,
                            Quantity = quantity,
                            ShippingCost = shippingCost
                        };
                    })
                    .ToArray();

                return cartItems;
            }
        }
    }
}
