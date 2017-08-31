using System.Collections.Generic;
using Warehouse.Data.Models;

namespace Warehouse.Data.Migrations
{
    internal static class Initial
    {
        internal static IEnumerable<StockItem> Data()
        {
            yield return new StockItem()
            {
                ProductId = 1,
                InStock = true
            };

            yield return new StockItem()
            {
                ProductId = 2,
                InStock = false,
            };
        }

    }
}
