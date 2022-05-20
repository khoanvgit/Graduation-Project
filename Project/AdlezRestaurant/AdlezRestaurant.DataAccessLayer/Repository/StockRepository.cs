using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(RMContext context) : base(context)
        {
        }
    }
}
