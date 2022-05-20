using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(RMContext context)
        {
            Context = context;
        }
        public RMContext Context { get; }


        private IAccountRepository _accountRepository;
        private ICustomerRepository _customerRepository;
        private IDishRepository _dishRepository;
        private IDishTypeRepository _dishTypeRepository;
        private IGoodsReceiptNoteRepository _goodsReceiptNoteRepository;
        private IGroupDivisionRepository _groupDivisionRepository;
        private IGroupRepository _groupRepository;
        private IIngredientRepository _ingredientRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderRepository _orderRepository;
        private IPaymentRepository _paymentRepository;
        private IReservationRepository _reservationRepository;
        private IReviewRepository _reviewRepository;
        private IShiftDetailRepository _shiftDetailRepository;
        private IShiftRepository _shiftRepository;
        private IStaffRepository _staffRepository;
        private IStockInRepository _stockInRepository;
        private IStockRepository _stockRepository;
        private ITableRepository _tableRepository;
        private IUserRepository _userRepository;

        public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(Context);
        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(Context);
        public IDishRepository Dishes => _dishRepository ??= new DishRepository(Context);
        public IDishTypeRepository DishTypes => _dishTypeRepository ??= new DishTypeRepository(Context);
        public IGoodsReceiptNoteRepository GoodsReceiptNotes => _goodsReceiptNoteRepository ??= new GoodsReceiptNoteRepository(Context);
        public IGroupDivisionRepository GroupDivisions => _groupDivisionRepository ??= new GroupDivisionRepository(Context);
        public IGroupRepository Groups => _groupRepository ??= new GroupRepository(Context);
        public IIngredientRepository Ingredients => _ingredientRepository ??= new IngredientRepository(Context);
        public IOrderDetailRepository OrderDetails => _orderDetailRepository ??= new OrderDetailRepository(Context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(Context);
        public IPaymentRepository Payments => _paymentRepository ??= new PaymentRepository(Context);
        public IReservationRepository Reservations => _reservationRepository ??= new ReservationRepository(Context);
        public IReviewRepository Reviews => _reviewRepository ??= new ReviewRepository(Context);
        public IShiftDetailRepository ShiftDetails => _shiftDetailRepository ??= new ShiftDetailRepository(Context);
        public IShiftRepository Shifts => _shiftRepository ??= new ShiftRepository(Context);
        public IStaffRepository Staffs => _staffRepository ??= new StaffRepository(Context);
        public IStockInRepository StockIns => _stockInRepository ??= new StockInRepository(Context);
        public IStockRepository Stocks => _stockRepository ??= new StockRepository(Context);
        public ITableRepository Tables => _tableRepository ??= new TableRepository(Context);
        public IUserRepository Users => _userRepository ??= new UserRepository(Context);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
