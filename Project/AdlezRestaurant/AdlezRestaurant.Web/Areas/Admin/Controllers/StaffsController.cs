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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using static AdlezRestaurant.Web.Helpers.Helper;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StaffsController : Controller
    {
        private readonly IUnitOfWork _context;
        private IWebHostEnvironment _webHostEnvironment;

        public StaffsController(RMContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = new UnitOfWork(context);
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Staffs
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.groups = _context.Groups.GetAll().ToList();
            return View(await _context.Staffs.GetAll().ToListAsync());
        }

        // GET: Admin/Staffs/CreateOrEdit
        // GET: Admin/Staffs/CreateOrEdit/3
        [Authorize(Roles = "Admin")]
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.isMale = "checked";
                ViewData["GroupId"] = new SelectList(_context.Groups.GetAll(), "GroupId", "Name");
                return View(new Staff());
            }
            else
            {
                var staff = await _context.Staffs.FindAsync(id);
                if (staff == null)
                {
                    return NotFound();
                }
                ViewData["GroupId"] = new SelectList(_context.Groups.GetAll(), "GroupId", "Name", staff.GroupId);
                if (staff.Gender == "M")
                {
                    ViewBag.isMale = "checked";
                }
                else if (staff.Gender == "F")
                {
                    ViewBag.isFemale = "checked";
                }
                else if (staff.Gender == "O")
                {
                    ViewBag.isOther = "checked";
                }
                return View(staff);
            }

        }

        // POST: Admin/Staffs/CreateOrEdit
        // POST: Admin/Staffs/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, string gender, string kimage, [Bind("StaffId,GroupId,FirstName,LastName,Email,Address,City,Phone,Birthday,Image")] Staff staff, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (kimage != null)
                {
                    staff.Image = kimage;
                }
                if (Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "StaffImages");
                    string filePath = Path.Combine(uploadsFolder, Image.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }

                    staff.Image = Image.FileName;
                }

                staff.Gender = gender.ToUpper();
                if (id == 0)
                {
                    _context.Staffs.Add(staff);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Staffs.Update(staff);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StaffExists(staff.StaffId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                string htmlString = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Staffs.GetAll().ToList());
                return Json(new { isValid = true, html = htmlString });
            }
            ViewData["GroupId"] = new SelectList(_context.Groups.GetAll(), "GroupId", "Name", staff.GroupId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", staff) });
        }

        // POST: Admin/Staffs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Staffs.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Staffs.GetAll().ToList()) });
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.GetAll().Any(e => e.StaffId == id);
        }

        [Authorize(Roles = "Admin, Chef, Waiter_waitress")]
        public IActionResult Schedule()
        {
            var sds = _context.ShiftDetails.GetAll().Include(s => s.Staff).Include(s => s.Shift).ToList();
            return View(sds);
        }
    }
}
