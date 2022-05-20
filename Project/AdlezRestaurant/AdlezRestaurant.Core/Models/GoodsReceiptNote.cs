using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class GoodsReceiptNote
    {
        public int StockInId { get; set; }
        public int IngredientId { get; set; }

        [Display(Name = "Unit price")]
        public decimal GoodsUnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public int GoodsNumber { get; set; }
        public string Location { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual StockIn StockIn { get; set; }
    }
}
