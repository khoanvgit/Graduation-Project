using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.Web.Helpers;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static AdlezRestaurant.Web.Helpers.Helper;
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DishesController : Controller
    {
        private readonly IUnitOfWork _context;
        private IWebHostEnvironment _webHostEnvironment;

        public DishesController(RMContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = new UnitOfWork(context);
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Dishes
        public async Task<IActionResult> Index()
        {
            var rMContext = _context.Dishes.GetAll().Include(d => d.DishType);
            return View(await rMContext.ToListAsync());
        }

        // GET: Admin/Dishes/CreateOrEdit
        // GET: Admin/Dishes/CreateOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id=0)
        {
            if (id == 0)
            {
                ViewData["DishTypeId"] = new SelectList(_context.DishTypes.GetAll(), "DishTypeId", "Name");
                return View(new Dish());
            }
            else
            {
                var dish = await _context.Dishes.FindAsync(id);
                if (dish == null)
                {
                    return NotFound();
                }
                ViewData["DishTypeId"] = new SelectList(_context.DishTypes.GetAll(), "DishTypeId", "Name", dish.DishTypeId);
                return View(dish);
            }
        }

        // POST: Admin/Dishes/CreateOrEdit
        // POST: Admin/Dishes/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id,string kimage, [Bind("DishId,DishTypeId,Name,Description,Price,Image")] Dish dish, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (kimage != null)
                {
                    dish.Image = kimage;
                }
                if (Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "DishImages");
                    string filePath = Path.Combine(uploadsFolder, Image.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }

                    dish.Image = Image.FileName;
                }

                if (id == 0)
                {
                    _context.Dishes.Add(dish);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Dishes.Update(dish);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DishExists(dish.DishId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Dishes.GetAll().ToList()) });
            }
            ViewData["DishTypeId"] = new SelectList(_context.DishTypes.GetAll(), "DishTypeId", "Name", dish.DishTypeId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", dish) });
        }

        // GET: Admin/Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.GetAll()
                .Include(d => d.DishType)
                .FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Admin/Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Dishes.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Dishes.GetAll().ToList()) });
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.GetAll().Any(e => e.DishId == id);
        }
    }
}
