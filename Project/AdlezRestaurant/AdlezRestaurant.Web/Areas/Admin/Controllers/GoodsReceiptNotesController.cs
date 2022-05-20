using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using AdlezRestaurant.Web.Const;
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Chef")]
    public class GoodsReceiptNotesController : Controller
    {
        private readonly IUnitOfWork _context;
        static ReceiptNote rn = new ReceiptNote();

        public GoodsReceiptNotesController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        public async Task<IActionResult> Index(string showAll)
        {
            if(showAll == "show")
            {
                return View(await _context.StockIns.GetAll().Include(s => s.Staff).ToListAsync());
            }
            return View(await _context.StockIns.GetAll().Include(s => s.Staff).Where(s => s.Status != ReceiptNoteStatus.Trash && s.Status != ReceiptNoteStatus.Declined).ToListAsync());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReceiptNote receiptNote = new ReceiptNote();
            var stockIn = _context.StockIns.GetAll().FirstOrDefault(s => s.StockInId == id);
            var staff = _context.Staffs.GetEntity(stockIn.StaffId);
            var grns = _context.GoodsReceiptNotes.GetAll().Include(g => g.Ingredient).Where(grn => grn.StockInId == id).ToList();
            receiptNote.StockInId = stockIn.StockInId;
            receiptNote.StaffName = staff.FirstName + " " + staff.LastName;
            receiptNote.CreatedDate = stockIn.ReceiveDate;
            receiptNote.Status = stockIn.Status;
            receiptNote.GoodsReceiptNotes = grns;
            double totalM = 0;
            foreach (var item in grns)
            {
                totalM += Convert.ToDouble(item.GoodsNumber) * Convert.ToDouble(item.GoodsUnitPrice);
            }
            receiptNote.TotalMoney = totalM;

            return View(receiptNote);
        }

        public IActionResult Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReceiptNote receiptNote = new ReceiptNote();
            var stockIn = _context.StockIns.GetAll().FirstOrDefault(s => s.StockInId == id);
            var staff = _context.Staffs.GetEntity(stockIn.StaffId);
            var grns = _context.GoodsReceiptNotes.GetAll().Include(g => g.Ingredient).Where(grn => grn.StockInId == id).ToList();
            receiptNote.StockInId = stockIn.StockInId;
            receiptNote.StaffName = staff.FirstName + " " + staff.LastName;
            receiptNote.CreatedDate = stockIn.ReceiveDate;
            receiptNote.Status = stockIn.Status;
            receiptNote.GoodsReceiptNotes = grns;
            double totalM = 0;
            foreach (var item in grns)
            {
                totalM += Convert.ToDouble(item.GoodsNumber) * Convert.ToDouble(item.GoodsUnitPrice);
            }
            receiptNote.TotalMoney = totalM;

            return View(receiptNote);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            if (id == 0)
            {
                rn.Ingredients = _context.Ingredients.GetAll().ToList();

                rn.StockInId = _context.StockIns.GetAll().OrderBy(s => s.StockInId).LastOrDefault().StockInId + 1;
                rn.CreatedDate = DateTime.Now;
                var staff = GetLoginStaff();
                if (staff != null)
                {
                    rn.StaffId = staff.StaffId;
                    rn.StaffName = staff.FirstName + " " + staff.LastName;
                }
                else
                {
                    rn.StaffId = 0;
                    rn.StaffName = "???";
                }
                ViewBag.ExcludedIngredients = _context.Ingredients.GetAll().ToList(); //fix loi chung edit
                ViewBag.mode = "create";
                return View(rn);
            }
            else
            {
                ReceiptNote receiptNote = new ReceiptNote();
                var stockIn = _context.StockIns.GetAll().FirstOrDefault(s => s.StockInId == id);
                var staff = _context.Staffs.GetEntity(stockIn.StaffId);
                var grns = _context.GoodsReceiptNotes.GetAll().Include(g => g.Ingredient).Where(grn => grn.StockInId == id).ToList();
                receiptNote.StockInId = stockIn.StockInId;
                receiptNote.StaffName = staff.FirstName + " " + staff.LastName;
                receiptNote.CreatedDate = stockIn.ReceiveDate;
                receiptNote.Status = stockIn.Status;
                receiptNote.GoodsReceiptNotes = grns;
                receiptNote.Ingredients = _context.Ingredients.GetAll().Where(i => !grns.Select(g => g.IngredientId).Contains(i.IngredientId)).ToList();
                ViewBag.ExcludedIngredients = _context.Ingredients.GetAll().Where(i => grns.Select(g => g.IngredientId).Contains(i.IngredientId)).ToList();
                double totalM = 0;
                foreach (var item in grns)
                {
                    totalM += Convert.ToDouble(item.GoodsNumber) * Convert.ToDouble(item.GoodsUnitPrice);
                }
                receiptNote.TotalMoney = totalM;
                ViewBag.mode = "edit";
                return View(receiptNote);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrEdit(int id, IFormCollection frm)
        {

            if (id == 0)
            {
                if (int.Parse(frm["totalRow"]) >= 1)
                {
                    StockIn stckin = new StockIn()
                    {
                        StaffId = rn.StaffId,
                        ReceiveDate = rn.CreatedDate,
                        Status = ReceiptNoteStatus.Pending
                    };
                    _context.StockIns.Add(stckin, true);

                    for (int i = 1; i <= int.Parse(frm["totalRow"]); i++)
                    {
                        var ingrId = int.Parse(frm[$"addIngr{i}"]);
                        var ingr = _context.Ingredients.GetAll().FirstOrDefault(i => i.IngredientId == ingrId);
                        GoodsReceiptNote grn = new GoodsReceiptNote()
                        {
                            StockInId = rn.StockInId,
                            IngredientId = ingrId,
                            GoodsUnitPrice = Convert.ToDecimal(ingr.EstimatedPrice),
                            GoodsNumber = int.Parse(frm[$"ingrQuan{i}"]),
                            Location = "Hanoi, Vietnam"
                        };

                        _context.GoodsReceiptNotes.Add(grn);
                    }

                    _context.Save(); 
                }
                else
                {
                    TempData["errMsg"] = "Invalid action, please check again before click !";
                    return RedirectToAction("CreateOrEdit");
                }
            }
            else
            {
                if (int.Parse(frm["totalRow"]) >= 1)
                {
                    var grns = _context.GoodsReceiptNotes.GetAll().Include(g => g.Ingredient).Where(grn => grn.StockInId == id).ToList();
                    for (int j = 0; j < grns.Count; j++)
                    {
                        _context.GoodsReceiptNotes.Delete(grns[j]);
                    }
                    _context.Save();

                    for (int i = 1; i <= int.Parse(frm["totalRow"]); i++)
                    {
                        var ingrId = int.Parse(frm[$"addIngr{i}"]);
                        var ingr = _context.Ingredients.GetAll().FirstOrDefault(i => i.IngredientId == ingrId);
                        GoodsReceiptNote grn = new GoodsReceiptNote()
                        {
                            StockInId = id,
                            IngredientId = ingrId,
                            GoodsUnitPrice = Convert.ToDecimal(ingr.EstimatedPrice),
                            GoodsNumber = int.Parse(frm[$"ingrQuan{i}"]),
                            Location = "Hanoi, Vietnam"
                        };
                        _context.GoodsReceiptNotes.Add(grn);
                    }
                    _context.Save();
                }
                else
                {
                    TempData["errMsg"] = "Invalid action, please check again before click !";
                    return RedirectToAction("CreateOrEdit", id);
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Admin/GoodsReceiptNotes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _context.StockIns.GetEntity(id).Status = ReceiptNoteStatus.Trash;
            await _context.SaveAsync();
            TempData["undo"] = "undoAction";
            return RedirectToAction(nameof(Index));
        }

        private Staff GetLoginStaff()
        {
            var currentUser = _context.Users.GetAll().FirstOrDefault(u => u.UserName == User.Identity.Name);
            var staff = _context.Staffs.GetAll().FirstOrDefault(s => s.Email == currentUser.Email || s.Phone == currentUser.PhoneNumber);
            return staff;
        }
    }
}
