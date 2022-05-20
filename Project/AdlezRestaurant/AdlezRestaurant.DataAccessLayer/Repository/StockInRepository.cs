using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class StockInRepository : BaseRepository<StockIn>, IStockInRepository
    {
        public StockInRepository(RMContext context) : base(context)
        {
        }
    }
}
