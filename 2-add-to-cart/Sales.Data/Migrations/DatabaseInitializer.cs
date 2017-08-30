using Sales.Data.Context;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Sales.Data.Migrations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            context.ProductsPrices.AddOrUpdate(k => k.Id, Initial.Data().ToArray());
        }
    }
}
