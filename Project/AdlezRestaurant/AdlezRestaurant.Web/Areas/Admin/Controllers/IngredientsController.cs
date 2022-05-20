using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using static AdlezRestaurant.Web.Helpers.Helper;
using AdlezRestaurant.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Chef")]
    public class IngredientsController : Controller
    {
        private readonly IUnitOfWork _context;
        private IWebHostEnvironment _webHostEnvironment;

        public IngredientsController(RMContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = new UnitOfWork(context);
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredients.GetAll().ToListAsync());
        }

        // GET: Admin/Ingredients/CreateOrEdit
        // GET: Admin/Ingredients/CreateOrEdit/2
        [NoDirectAccess]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Ingredient());
            }
            else
            {
                var ingredient = await _context.Ingredients.FindAsync(id);
                if (ingredient == null)
                {
                    return NotFound();
                }
                return View(ingredient);
            }
        }

        // POST: Admin/Ingredients/CreateOrEdit
        // POST: Admin/Ingredients/CreateOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int id,string kimage, [Bind("IngredientId,Name,CalculationUnit,EstimatedPrice,Description,Image")] Ingredient ingredient, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if(kimage != null)
                {
                    ingredient.Image = kimage;
                }
                if (Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "StaffImages");
                    string filePath = Path.Combine(uploadsFolder, Image.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }

                    ingredient.Image = Image.FileName;
                }

                if (id == 0)
                {
                    _context.Ingredients.Add(ingredient);
                    await _context.SaveAsync();
                }
                else
                {
                    try
                    {
                        _context.Ingredients.Update(ingredient);
                        await _context.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!IngredientExists(ingredient.IngredientId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Ingredients.GetAll().ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", ingredient) });
        }

        // POST: Admin/Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Delete(id);
            await _context.SaveAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Ingredients.GetAll().ToList()) });
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.GetAll().Any(e => e.IngredientId == id);
        }
    }
}
