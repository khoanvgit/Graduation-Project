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
    public class GroupsController : Controller
    {
        private readonly IUnitOfWork _context;

        public GroupsController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Groups
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groups.GetAll().ToListAsync());
        }

        // GET: Admin/Groups/CreateOrEdit
        // GET: Admin/Groups/CreateOrEdit/3
        [Authorize(Roles = "Admin")]
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Group());
            }
            else
            {
                var @group = await _context.Groups.FindAsync(id);
                if (@group == null)
                {
                    return NotFound();
                }
                return View(@group);
            }
        }

        // POST: Admin/Groups/CreateOrEdit
        // POST: Admin/Groups/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id, [Bind("GroupId,Name,Description")] Group @group)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Groups.Add(@group);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Groups.Update(@group);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GroupExists(@group.GroupId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", @group) });
        }

        // POST: Admin/Groups/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Groups.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.GetAll().ToList()) });
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.GetAll().Any(e => e.GroupId == id);
        }
    }
}
