using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(RMContext context) : base(context)
        {
        }
    }
}
