using Marketing.Data.Context;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Marketing.Data.Migrations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<MarketingContext>
    {
        protected override void Seed(MarketingContext context)
        {
            context.ProductsDetails.AddOrUpdate(k => k.Id, Initial.Data().ToArray());
        }
    }
}
