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
using Microsoft.AspNetCore.Http;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShiftsController : Controller
    {
        private readonly IUnitOfWork _context;

        public ShiftsController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Shifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shifts.GetAll().ToListAsync());
        }

        // GET: Admin/Shifts/CreateOrEdit
        // GET: Admin/Shifts/CreateOrEdit/3
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Shift());
            }
            else
            {
                var shift = await _context.Shifts.FindAsync(id);
                if (shift == null)
                {
                    return NotFound();
                }
                return View(shift);
            }
        }

        // POST: Admin/Shifts/CreateOrEdit
        // POST: Admin/Shifts/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("ShiftId,Name,TimeBegin,TimeFinish")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Shifts.Add(shift);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Shifts.Update(shift);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ShiftExists(shift.ShiftId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shifts.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", shift) });
        }

        // POST: Admin/Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Shifts.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shifts.GetAll().ToList()) });
        }

        private bool ShiftExists(int id)
        {
            return _context.Shifts.GetAll().Any(e => e.ShiftId == id);
        }

        [NoDirectAccess]
        public IActionResult ManageStaff(int id)
        {
            var sds = _context.ShiftDetails.GetAll().Where(s => s.ShiftId == id).Include(s => s.Staff).Include(s => s.Shift).ToList();
            ViewBag.ShiftId = id;
            ViewBag.ShiftName = _context.Shifts.GetEntity(id).Name;
            ViewData["StaffInfo"] = _context.Staffs.GetAll().ToList();
            if (sds == null)
            {
                return NotFound();
            }
            return View(sds);
        }

        public IActionResult SaveManageStaff(int id, IFormCollection frm)
        {
            foreach (var item in _context.Staffs.GetAll().ToList())
            {
                string viewName = "checkStaff" + item.StaffId;
                if (frm[$"{viewName}"].ToString() == "True")
                {
                    ShiftDetail sd = new ShiftDetail()
                    {
                        ShiftId = id,
                        StaffId = item.StaffId,
                    };
                    if (!_context.ShiftDetails.GetAll().Contains(sd))
                    {
                        _context.ShiftDetails.Add(sd);
                    }
                }
                else
                {
                    var sd = _context.ShiftDetails.GetAll().FirstOrDefault(sd => sd.StaffId == item.StaffId && sd.ShiftId == id);
                    if (_context.ShiftDetails.GetAll().Contains(sd))
                    {
                        _context.ShiftDetails.Delete(sd);
                    }
                }
            }
            _context.Save();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shifts.GetAll().ToList()) });
        }
    }
}
