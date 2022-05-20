using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class ShiftDetailRepository : BaseRepository<ShiftDetail>, IShiftDetailRepository
    {
        public ShiftDetailRepository(RMContext context) : base(context)
        {
        }
    }
}
