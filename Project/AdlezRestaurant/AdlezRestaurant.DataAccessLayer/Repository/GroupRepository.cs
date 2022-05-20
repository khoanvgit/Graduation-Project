using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(RMContext context) : base(context)
        {
        }
    }
}
