using AdlezRestaurant.Core.Models;
using System.Collections.Generic;

namespace AdlezRestaurant.Web.Areas.Admin.ViewModels
{
    public class GeneralModel
    {
        public GeneralModel()
        {
            Dishes = new List<Dish>();
            DishTypes = new List<DishType>();
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
            Tables = new List<Table>();
        }

        public GeneralModel(List<Dish> dishes, List<DishType> dishTypes, List<Order> orders, List<OrderDetail> orderDetails, List<Table> tables)
        {
            Dishes = dishes;
            DishTypes = dishTypes;
            Orders = orders;
            OrderDetails = orderDetails;
            Tables = tables;
        }

        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<DishType> DishTypes { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}
