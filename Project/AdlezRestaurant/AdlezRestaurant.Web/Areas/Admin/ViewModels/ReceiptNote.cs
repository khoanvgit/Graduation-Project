using AdlezRestaurant.Core.Models;
using System;
using System.Collections.Generic;

namespace AdlezRestaurant.Web.Areas.Admin.ViewModels
{
    public class ReceiptNote
    {
        public ReceiptNote()
        {
            GoodsReceiptNotes = new List<GoodsReceiptNote>();
            Ingredients = new List<Ingredient>();
        }

        public int StockInId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public double TotalMoney { get; set; }
        public List<GoodsReceiptNote> GoodsReceiptNotes { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
