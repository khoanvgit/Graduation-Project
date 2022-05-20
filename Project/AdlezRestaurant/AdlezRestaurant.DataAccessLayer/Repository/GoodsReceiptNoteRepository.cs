using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class GoodsReceiptNoteRepository : BaseRepository<GoodsReceiptNote>, IGoodsReceiptNoteRepository
    {
        public GoodsReceiptNoteRepository(RMContext context) : base(context)
        {
        }
    }
}
