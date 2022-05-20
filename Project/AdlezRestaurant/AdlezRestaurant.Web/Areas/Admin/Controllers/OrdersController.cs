using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _context;

        public OrdersController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Orders/Create
        public IActionResult Create(int tableNumber)
        {
            ViewBag.tableNumber = tableNumber;
            ViewBag.now = DateTime.Now.ToString();
            ViewData["CustomerId"] = new SelectList(_context.Customers.GetAll(), "CustomerId", "FirstName");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,TableNumber,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.Tables.GetAll().FirstOrDefault(t => t.Number == order.TableNumber).Status = TableStatus.Busy;
                await _context.SaveAsync();
                return RedirectToAction("Index", "Main");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers.GetAll(), "CustomerId", "FirstName", order.CustomerId);
            return View(order);
        }
    }
}
