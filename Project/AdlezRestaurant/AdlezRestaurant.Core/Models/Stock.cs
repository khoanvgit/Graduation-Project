using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string CalculationUnit { get; set; }
        public int Quantity { get; set; }
    }
}
