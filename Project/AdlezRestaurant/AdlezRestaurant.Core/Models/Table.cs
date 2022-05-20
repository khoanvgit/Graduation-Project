using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Table
    {
        public Table()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Number { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
