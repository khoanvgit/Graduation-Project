using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Helpers;
using static AdlezRestaurant.Web.Helpers.Helper;
using AdlezRestaurant.Web.Const;
using AdlezRestaurant.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _context;

        public CustomersController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.GetAll().Where(c => c.LastName != null && c.Email != null).ToListAsync());
        }

        // GET: Admin/Customers/CreateOrEdit
        // GET: Admin/Customers/CreateOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Customer());
            }
            else
            {
                var customer = await _context.Customers.GetAll().FindAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
        }

        // POST: Admin/Customers/CreateOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("CustomerId,FirstName,LastName,Email,Address,City,Phone,Birthday")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Customers.Add(customer);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Customers.Update(customer);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(customer.CustomerId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Customers.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", customer) });
        }

        // GET: Admin/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.GetAll()
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Customers.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Customers.GetAll().ToList()) });
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.GetAll().Any(e => e.CustomerId == id);
        }
    }
}
