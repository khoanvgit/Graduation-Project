using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.IRepository;
using System;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public RMContext Context { get; }

        public IAccountRepository Accounts { get; }
        public ICustomerRepository Customers { get; }
        public IDishRepository Dishes { get; }
        public IDishTypeRepository DishTypes { get; }
        public IGoodsReceiptNoteRepository GoodsReceiptNotes { get; }
        public IGroupDivisionRepository GroupDivisions { get; }
        public IGroupRepository Groups { get; }
        public IIngredientRepository Ingredients { get; }
        public IOrderDetailRepository OrderDetails { get; }
        public IOrderRepository Orders { get; }
        public IPaymentRepository Payments { get; }
        public IReservationRepository Reservations { get; }
        public IReviewRepository Reviews { get; }
        public IShiftDetailRepository ShiftDetails { get; }
        public IShiftRepository Shifts { get; }
        public IStaffRepository Staffs { get; }
        public IStockInRepository StockIns { get; }
        public IStockRepository Stocks { get; }
        public ITableRepository Tables { get; }
        public IUserRepository Users { get; }

        public void Save();
        public Task SaveAsync();

    }
}
