using Marketing.Data.Context;
using System.Linq;
using System.Web.Http;

namespace Marketing.API.Controllers
{
    [RoutePrefix("api/product-details")]
    public class ProductsDetailsController : ApiController
    {
        [HttpGet]
        [Route("product/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new MarketingContext())
            {
                var item = db.ProductsDetails
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }
    }
}
