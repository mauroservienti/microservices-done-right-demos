using Sales.Data.Migrations;
using Sales.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Sales.Data.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("Sales")
        {
        }

        public IDbSet<ProductPrice> ProductsPrices { get; set; }
        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<ProductPrice>();

            var cartEntity = modelBuilder.Entity<ShoppingCart>();

            cartEntity
                .HasKey(c => c.Id)
                .HasMany(c => c.Items)
                .WithRequired()
                .HasForeignKey(k => k.CartId)
                .WillCascadeOnDelete();

            cartEntity
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}
