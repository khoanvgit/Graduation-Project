using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.Core.Models;
using Microsoft.AspNetCore.Http;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;
using Microsoft.AspNetCore.Authorization;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StocksController : Controller
    {
        private readonly IUnitOfWork _context;

        public StocksController(RMContext context)
        {
            _context = new UnitOfWork(context);
        }

        // GET: Admin/Stocks
        public async Task<IActionResult> Index(int loadNumber, string sortOpt)
        {
            if (loadNumber > 6)
            {
                ViewBag.ingredients = _context.Ingredients.GetAll().Take(loadNumber).ToList();
                ViewBag.loadNumber = loadNumber + 6;
            }
            else
            {
                ViewBag.ingredients = _context.Ingredients.GetAll().Take(6).ToList();
                ViewBag.loadNumber = loadNumber + 6;
            }

            var stocks = await _context.Stocks.GetAll().ToListAsync();

            if (sortOpt == SortOption.ASC)
            {
                stocks = stocks.OrderBy(s => s.Quantity).ToList();
                ViewBag.sortOpt = SortOption.ASC;
            }
            else if (sortOpt == SortOption.DESC)
            {
                stocks = stocks.OrderByDescending(s => s.Quantity).ToList();
                ViewBag.sortOpt = SortOption.DESC;
            }

            return View(stocks);
        }

        // GET: Admin/Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,IngredientId,Name,CalculationUnit,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Stocks.Add(stock);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Admin/Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Admin/Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,IngredientId,Name,CalculationUnit,Quantity")] Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Stocks.Update(stock);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.GetAll().Any(e => e.StockId == id);
        }

        [HttpPost]
        public IActionResult UpdateStock(int stockInId, int totalCount, IFormCollection frm)
        {
            if (stockInId == 0)
            {
                return NotFound();
            }

            for (int i = 0; i < totalCount; i++)
            {
                if (_context.Stocks.GetAll().Select(s => s.IngredientId).Contains(int.Parse(frm[$"ingrId{i}"])))
                {
                    _context.Stocks.GetAll().FirstOrDefault(s => s.IngredientId == int.Parse(frm[$"ingrId{i}"])).Quantity += int.Parse(frm[$"quantity{i}"]);
                }
                else
                {
                    Stock stck = new Stock()
                    {
                        IngredientId = int.Parse(frm[$"ingrId{i}"]),
                        Name = frm[$"ingrName{i}"],
                        CalculationUnit = frm[$"calUnit{i}"],
                        Quantity = int.Parse(frm[$"quantity{i}"])
                    };
                    _context.Stocks.Add(stck);
                }
            }
            _context.StockIns.GetEntity(stockInId).Status = ReceiptNoteStatus.Arrived;
            _context.Save();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Chef")]
        [HttpGet]
        public IActionResult ReportLeftIngredient()
        {
            return View(_context.Stocks.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult SubmitReport(IFormCollection frm)
        {
            var stocks = _context.Stocks.GetAll().ToList();
            int d = 0;
            foreach (var item in stocks)
            {
                string nquantity = "report" + item.StockId + "modified";
                if (!string.IsNullOrEmpty(frm[$"{nquantity}"]))
                {
                    item.Quantity = int.Parse(frm[$"{nquantity}"]);
                }
                else
                {
                    d++;
                }
            }
            if(d == stocks.Count)
            {
                TempData["msgError"] = "Nothing change";
                return View("ReportLeftIngredient", _context.Stocks.GetAll().ToList());
            }
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
