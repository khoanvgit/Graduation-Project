using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(RMContext context) : base(context)
        {
        }
    }
}
