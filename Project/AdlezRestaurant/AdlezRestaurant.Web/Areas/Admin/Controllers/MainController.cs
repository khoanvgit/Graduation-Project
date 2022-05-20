using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Areas.Admin.ViewModels;
using AdlezRestaurant.Web.Const;
using AdlezRestaurant.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdlezRestaurant.Web.Helpers.Helper;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MainController : Controller
    {
        private readonly IUnitOfWork db;
        private GeneralModel generalModel;

        public MainController(RMContext Context)
        {
            db = new UnitOfWork(Context);
            var dishes = db.Dishes.GetAll().ToList();
            var dishTypes = db.DishTypes.GetAll().ToList();
            var orders = db.Orders.GetAll().Where(o => db.Payments.GetAll().All(p => p.OrderId != o.OrderId)).Include(o => o.Customer).ToList();
            var orderDetails = db.OrderDetails.GetAll().Where(o => db.Payments.GetAll().All(p => p.OrderId != o.OrderId)).ToList();
            var tables = db.Tables.GetAll().ToList();

            generalModel = new GeneralModel(dishes, dishTypes, orders, orderDetails, tables);
        }

        public IActionResult Index()
        {
            ViewBag.Order = new SelectList(db.Orders.GetAll().ToList(), "OrderID", "TableNumber");
            return View(generalModel);
        }

        [HttpPost]
        public IActionResult Detail(int? number)
        {
            ViewBag.on = number;
            ViewBag.Status = generalModel.Tables.FirstOrDefault(t => t.Number == number).Status;
            ViewBag.Customers = db.Customers.GetAll().ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Detail", generalModel) });
        }

        [HttpPost]
        public IActionResult AddDish(int dishId, int orderId, int number, int? tableNumber)
        {
            ViewBag.on = tableNumber;
            ViewBag.Status = TableStatus.Busy;
            if (dishId != 0 && orderId != 0 && number != 0)
            {
                var order = generalModel.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order.OrderDetails.Where(o => o.OrderId == orderId).Select(od => od.DishId).Contains(dishId))
                {
                    var orderDetail = order.OrderDetails.Where(o => o.OrderId == orderId).FirstOrDefault(od => od.DishId == dishId);
                    orderDetail.DishNumber += number;
                }
                else
                {
                    var orderDetail = new OrderDetail() { OrderId = orderId, DishId = dishId, DishNumber = number };
                    order.OrderDetails.Add(orderDetail);
                }
                db.Save();
            }
            generalModel.OrderDetails = db.OrderDetails.GetAll().Where(o => db.Payments.GetAll().All(p => p.OrderId != o.OrderId)).ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Detail", generalModel) });
        }

        [HttpPost]
        public IActionResult CancelDish(int dishId, int orderId, int? tableNumber)
        {
            ViewBag.on = tableNumber;
            ViewBag.Status = TableStatus.Busy;
            if (dishId != 0 && orderId != 0)
            {
                var order = generalModel.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order.OrderDetails.Where(o => o.OrderId == orderId).Select(od => od.DishId).Contains(dishId))
                {
                    var orderDetail = order.OrderDetails.Where(o => o.OrderId == orderId).FirstOrDefault(od => od.DishId == dishId);
                    db.OrderDetails.Delete(orderDetail);
                    db.Save();
                }
            }
            generalModel.OrderDetails = db.OrderDetails.GetAll().Where(o => db.Payments.GetAll().All(p => p.OrderId != o.OrderId)).ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Detail", generalModel) });
        }

        [HttpPost]
        public IActionResult Paying(int orderId, int customerId, string mop)
        {
            if(generalModel.OrderDetails.Where(od => od.OrderId == orderId).Count() < 1)
            {
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_Tables", generalModel) });
            }
            decimal totalM = 0;
            var order = db.Orders.GetAll().FirstOrDefault(o => o.OrderId == orderId);
            foreach (var item in generalModel.OrderDetails)
            {
                if (item.Order.OrderId == orderId)
                {
                    totalM += (decimal)(item.Dish.Price * item.DishNumber);
                }
            }
            var payment = new Payment() { OrderId = orderId, CustomerId = customerId, ModeOfPayment = mop, TotalMoney = totalM, PaymentDate = System.DateTime.Now };
            db.Payments.Add(payment);
            db.Tables.GetAll().FirstOrDefault(t => t.Number == order.TableNumber).Status = TableStatus.Available;
            db.Save();

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Tables", generalModel) });
        }

        [HttpPost]
        public IActionResult CancelOrder(int? number)
        {
            ViewBag.on = number;
            ViewBag.Status = generalModel.Tables.FirstOrDefault(t => t.Number == number).Status;
            ViewBag.Customers = db.Customers.GetAll().ToList();
            var table = db.Tables.GetAll().FirstOrDefault(t => t.Number == number);
            if (table.Status == TableStatus.Busy)
            {
                var order = generalModel.Orders.FirstOrDefault(o => o.TableNumber == number);
                var orderDetails = db.OrderDetails.GetAll().Where(od => od.OrderId == order.OrderId);
                if (orderDetails.Count() > 0)
                {
                    foreach (var item in orderDetails.ToList())
                    {
                        db.OrderDetails.Delete(item);
                    }
                }
                db.Orders.Delete(order);
                table.Status = TableStatus.Available;
                db.Save();
            }

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Tables", generalModel) });
        }

        // GET: Admin/Customers/CreateAndOrder
        [NoDirectAccess]
        public IActionResult CreateAndOrder(int id, int tableNumber)
        {
            ViewBag.number = tableNumber;
            return View(new Customer());
        }

        // POST: Admin/Customers/CreateAndOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndOrder(int id, [Bind("CustomerId,FirstName,LastName,Email,Address,City,Phone,Birthday")] Customer customer, int customerTableNumber)
        {
            int tableNumber = customerTableNumber;
            ViewBag.number = tableNumber;
            ViewBag.on = tableNumber;
            ViewBag.status = TableStatus.Busy;
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.Save();
                var order = new Order() { CustomerId = customer.CustomerId, OrderDate = DateTime.Now, TableNumber = tableNumber };
                db.Orders.Add(order);
                db.Tables.GetAll().FirstOrDefault(t => t.Number == order.TableNumber).Status = TableStatus.Busy;
                await db.SaveAsync();

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Tables", generalModel) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateAndOrder", customer) });
        }

        public IActionResult ReservationRequest()
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach (var reser in db.Reservations.GetAll().Where(r => r.ReservedDate.Date == DateTime.Now.Date).ToList())
            {
                var timeRemain = (DateTime.Now - reser.ReservedDate).TotalMinutes;
                if (timeRemain <= 30)
                {
                    foreach (var table in db.Tables.GetAll().ToList())
                    {
                        if (reser.TableNumber == table.Number && table.Status == TableStatus.Wait)
                        {
                            reservations.Add(reser);
                        }
                    }
                }
            }
            return View(reservations);
        }

        public IActionResult MakeDecision(bool allApproved, bool allDeclined, int rid, string requestType, bool approved = false)
        {
            if (requestType == "Reservation")
            {
                List<Table> tables = db.Tables.GetAll().Where(t => t.Status == TableStatus.Wait).ToList();
                if (allApproved)
                {
                    foreach (var t in tables)
                    {
                        t.Status = TableStatus.Reserved;
                    }
                }
                else if (allDeclined)
                {
                    foreach (var t in tables)
                    {
                        t.Status = TableStatus.Available;
                    }
                }
                else
                {
                    var reser = db.Reservations.GetAll().FirstOrDefault(r => r.ReservationId == rid);
                    var table = db.Tables.GetAll().FirstOrDefault(t => t.Number == reser.TableNumber && t.Status == TableStatus.Wait);
                    if (approved)
                    {
                        table.Status = TableStatus.Reserved;
                    }
                    else
                    {
                        table.Status = TableStatus.Available;
                    }
                }
                db.Save();
                return RedirectToAction("ReservationRequest");
            }
            else if (requestType == "Ingredient")
            {
                List<StockIn> stis = db.StockIns.GetAll().Where(s => s.Status == ReceiptNoteStatus.Pending).ToList();
                if (allApproved)
                {
                    foreach (var s in stis)
                    {
                        s.Status = ReceiptNoteStatus.Approved;
                    }
                }
                else if (allDeclined)
                {
                    foreach (var s in stis)
                    {
                        s.Status = ReceiptNoteStatus.Declined;
                    }
                }
                else
                {
                    var sti = db.StockIns.GetAll().FirstOrDefault(s => s.StockInId == rid);
                    if (approved)
                    {
                        sti.Status = ReceiptNoteStatus.Approved;
                    }
                    else
                    {
                        sti.Status = ReceiptNoteStatus.Declined;
                    }
                }

                db.Save();
                return RedirectToAction("IngredientRequest");
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = Role.Admin)]
        public IActionResult IngredientRequest()
        {
            List<ReceiptNote> rns = new List<ReceiptNote>();
            foreach (var sti in db.StockIns.GetAll().Include(s => s.Staff).Where(s => s.Status == ReceiptNoteStatus.Pending || s.Status == ReceiptNoteStatus.Approved).ToList())
            {
                ReceiptNote rn = new ReceiptNote()
                {
                    StockInId = sti.StockInId,
                    StaffId = sti.StaffId,
                    StaffName = sti.Staff.FirstName + " " + sti.Staff.LastName,
                    CreatedDate = sti.ReceiveDate,
                    Status = sti.Status,
                    GoodsReceiptNotes = db.GoodsReceiptNotes.GetAll().Include(gr => gr.Ingredient).Where(grn => grn.StockInId == sti.StockInId).ToList(),
                    TotalMoney = Convert.ToDouble(db.GoodsReceiptNotes.GetAll().Where(grn => grn.StockInId == sti.StockInId)
                                .Sum(grn => Convert.ToDecimal(grn.GoodsNumber) * Convert.ToDecimal(grn.GoodsUnitPrice)))
                };
                rns.Add(rn);
            }

            return View(rns);
        }

        public IActionResult PrintInvoice(int orderId, int customerId)
        {
            if (orderId == 0 || customerId == 0)
            {
                return NotFound();
            }
            else
            {
                decimal subTotal = 0;
                var order = db.Orders.GetAll().FirstOrDefault(o => o.OrderId == orderId);
                var dishes = db.OrderDetails.GetAll().Include(od => od.Dish).Where(od => od.OrderId == order.OrderId);
                ViewBag.orderId = order.OrderId;
                ViewBag.customerName = db.Customers.GetEntity(customerId).FirstName + " " + db.Customers.GetEntity(customerId).LastName;
                ViewBag.orderDate = order.OrderDate;
                ViewBag.table = order.TableNumber;
                foreach (var item in dishes)
                {
                    subTotal += (decimal)(item.Dish.Price * item.DishNumber);
                }

                ViewBag.subTotal = subTotal.ToString("C2");
                ViewBag.tax = (subTotal * 5 / 100).ToString("C2");
                ViewBag.totalM = (subTotal + subTotal * 5 / 100).ToString("C2");
                return View(dishes);
            }
        }
    }
}
