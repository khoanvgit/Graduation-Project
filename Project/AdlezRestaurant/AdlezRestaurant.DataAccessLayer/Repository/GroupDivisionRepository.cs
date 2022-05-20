using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class GroupDivisionRepository : BaseRepository<GroupDivision>, IGroupDivisionRepository
    {
        public GroupDivisionRepository(RMContext context) : base(context)
        {
        }
    }
}
