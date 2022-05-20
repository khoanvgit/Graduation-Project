using System;
using System.Collections.Generic;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class GroupDivision
    {
        public int StaffId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
