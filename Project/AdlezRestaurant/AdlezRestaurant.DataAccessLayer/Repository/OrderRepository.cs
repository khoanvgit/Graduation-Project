using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(RMContext context) : base(context)
        {
        }
    }
}
