using Sales.Data.Models;
using System.Collections.Generic;

namespace Sales.Data.Migrations
{
    internal static class Initial
    {
        internal static IEnumerable<ProductPrice> Data()
        {
            yield return new ProductPrice()
            {
                ProductId = 1,
                Price= 10.00m
            };

            yield return new ProductPrice()
            {
                ProductId = 2,
                Price= 100.00m,
            };
        }

    }
}
