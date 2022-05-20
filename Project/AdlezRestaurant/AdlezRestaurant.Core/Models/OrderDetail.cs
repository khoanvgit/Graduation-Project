using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int DishNumber { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
