using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class ShiftDetail
    {
        public int ShiftId { get; set; }
        public int StaffId { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
