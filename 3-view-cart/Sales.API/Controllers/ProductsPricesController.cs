using Sales.Data.Context;
using System.Linq;
using System.Web.Http;

namespace Sales.API.Controllers
{
    [RoutePrefix("api/prices")]
    public class ProductsPricesController : ApiController
    {
        [HttpGet]
        [Route("product/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new SalesContext())
            {
                var item = db.ProductsPrices
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }
    }
}
