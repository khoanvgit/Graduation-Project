using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Content { get; set; }
    }
}
