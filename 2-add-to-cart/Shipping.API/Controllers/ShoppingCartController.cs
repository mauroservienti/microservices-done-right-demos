using System.Net;
using System.Web.Http;

namespace Shipping.API.Controllers
{
    public class ShoppingCartController : ApiController
    {
        [HttpPost]
        [Route("api/shopping-cart")]
        public IHttpActionResult AddToCart(dynamic data)
        {
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
