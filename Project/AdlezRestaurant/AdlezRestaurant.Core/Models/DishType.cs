using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class DishType
    {
        public DishType()
        {
            Dishes = new HashSet<Dish>();
        }

        public int DishTypeId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
