using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            GoodsReceiptNotes = new HashSet<GoodsReceiptNote>();
        }

        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [DisplayName("Unit")]
        public string CalculationUnit { get; set; }

        [DisplayName("Estimated price")]
        public decimal? EstimatedPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<GoodsReceiptNote> GoodsReceiptNotes { get; set; }
    }
}
