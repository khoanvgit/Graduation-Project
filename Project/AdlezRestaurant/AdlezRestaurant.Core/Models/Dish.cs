using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Dish
    {
        public Dish()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int DishId { get; set; }
        public int DishTypeId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal? Price { get; set; }
        public string Image { get; set; }

        public virtual DishType DishType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
