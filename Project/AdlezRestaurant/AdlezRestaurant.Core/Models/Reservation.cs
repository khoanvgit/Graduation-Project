using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        [DisplayName("Customer name")]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Reserved date")]
        public DateTime ReservedDate { get; set; }

        [DisplayName("Viproom")]
        public bool Viproom { get; set; }

        [Required]
        [DisplayName("Number of people")]
        public int NumberOfPeople { get; set; }

        [DisplayName("Table Number")]
        public int TableNumber { get; set; }

        public virtual Table TableNumberNavigation { get; set; }
    }
}
