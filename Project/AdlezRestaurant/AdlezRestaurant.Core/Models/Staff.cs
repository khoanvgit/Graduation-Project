using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class Staff
    {
        public Staff()
        {
            GroupDivisions = new HashSet<GroupDivision>();
            ShiftDetails = new HashSet<ShiftDetail>();
            StockIns = new HashSet<StockIn>();
        }

        public int StaffId { get; set; }
        [Display(Name = "Group")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "First name cannot be empty")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty")]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid mobile number.")]
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string Image { get; set; }

        public virtual ICollection<GroupDivision> GroupDivisions { get; set; }
        public virtual ICollection<ShiftDetail> ShiftDetails { get; set; }
        public virtual ICollection<StockIn> StockIns { get; set; }
    }
}
