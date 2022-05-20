using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdlezRestaurant.Core.Models
{
    public partial class StockIn
    {
        public StockIn()
        {
            GoodsReceiptNotes = new HashSet<GoodsReceiptNote>();
        }

        public int StockInId { get; set; }
        public int StaffId { get; set; }

        [Display(Name = "Created date")]
        public DateTime ReceiveDate { get; set; }

        public string Status { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual ICollection<GoodsReceiptNote> GoodsReceiptNotes { get; set; }
    }
}
