using Marketing.Data.Migrations;
using Marketing.Data.Models;
using System.Data.Entity;

namespace Marketing.Data.Context
{
    public class MarketingContext : DbContext
    {
        public MarketingContext() : base("Marketing")
        {
        }

        public IDbSet<ProductDetails> ProductsDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<ProductDetails>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
