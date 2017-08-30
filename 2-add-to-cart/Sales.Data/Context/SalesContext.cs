using Sales.Data.Migrations;
using Sales.Data.Models;
using System.Data.Entity;

namespace Sales.Data.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("Sales")
        {
        }

        public IDbSet<ProductPrice> ProductsPrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<ProductPrice>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
