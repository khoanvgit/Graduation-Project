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
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DishTypesController : Controller
    {
        private readonly IUnitOfWork _context;

        public DishTypesController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/DishTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DishTypes.GetAll().ToListAsync());
        }

        // GET: Admin/DishTypes/CreateOrEdit
        // GET: Admin/DishTypes/CreateOrEdit/3
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new DishType());
            }
            else
            {
                var dishType = await _context.DishTypes.FindAsync(id);
                if (dishType == null)
                {
                    return NotFound();
                }
                return View(dishType);
            }
        }

        // POST: Admin/DishTypes/CreateOrEdit
        // POST: Admin/DishTypes/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("DishTypeId,Name,Description")] DishType dishType)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.DishTypes.Add(dishType);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.DishTypes.Update(dishType);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DishTypeExists(dishType.DishTypeId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.DishTypes.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", dishType) });
        }

        // POST: Admin/DishTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.DishTypes.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.DishTypes.GetAll().ToList()) });
        }

        private bool DishTypeExists(int id)
        {
            return _context.DishTypes.GetAll().Any(e => e.DishTypeId == id);
        }
    }
}
