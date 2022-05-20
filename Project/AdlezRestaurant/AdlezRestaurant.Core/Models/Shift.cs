using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftDetails = new HashSet<ShiftDetail>();
        }

        public int ShiftId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [DisplayName("Time begin")]
        public string TimeBegin { get; set; }

        [DisplayName("Time finish")]
        public string TimeFinish { get; set; }

        public virtual ICollection<ShiftDetail> ShiftDetails { get; set; }
    }
}
