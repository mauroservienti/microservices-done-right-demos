﻿namespace Warehouse.Data.Models
{
    public class StockItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public bool InStock{ get; set; }
    }
}