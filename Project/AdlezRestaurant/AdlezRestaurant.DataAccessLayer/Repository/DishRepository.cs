using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(RMContext context) : base(context)
        {
        }
    }
}
