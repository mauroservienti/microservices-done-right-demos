using System.Linq;
using System.Web.Http;
using Shipping.Data.Context;

namespace Shipping.API.Controllers
{
    [RoutePrefix("api/products")]
    public class ShippingDetailsController : ApiController
    {
        [HttpGet]
        [Route("shippingdetails/{id}")]
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
