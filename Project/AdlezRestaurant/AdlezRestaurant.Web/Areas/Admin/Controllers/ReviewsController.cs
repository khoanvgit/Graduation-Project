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

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewsController : Controller
    {
        private readonly IUnitOfWork _context;

        public ReviewsController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.GetAll().ToListAsync());
        }

        // GET: Admin/Reviews/CreateOrEdit
        // GET: Admin/Reviews/CreateOrEdit/3
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Review());
            }
            else
            {
                var review = await _context.Reviews.FindAsync(id);
                if (review == null)
                {
                    return NotFound();
                }
                return View(review);
            }
        }

        // POST: Admin/Reviews/CreateOrEdit
        // POST: Admin/Reviews/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("Id,CustomerName,Content")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.ReviewDate = DateTime.Now;
                if (id == 0)
                {
                    _context.Reviews.Add(review);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Reviews.Update(review);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ReviewExists(review.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Reviews.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", review) });
        }

        // POST: Admin/Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Reviews.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Reviews.GetAll().ToList()) });
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.GetAll().Any(e => e.Id == id);
        }
    }
}
