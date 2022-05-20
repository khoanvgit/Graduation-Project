using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupDivisions = new HashSet<GroupDivision>();
        }

        public int GroupId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GroupDivision> GroupDivisions { get; set; }
    }
}
