using Shipping.Data.Context;
using System.Linq;
using System.Web.Http;

namespace Shipping.API.Controllers
{
    [RoutePrefix("api/shipping-details")]
    public class ShippingDetailsController : ApiController
    {
        [HttpGet]
        [Route("product/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new ShippingContext())
            {
                var item = db.ProductsShippingDetails
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }
    }
}
