using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class DishTypeRepository : BaseRepository<DishType>, IDishTypeRepository
    {
        public DishTypeRepository(RMContext context) : base(context)
        {
        }
    }
}
