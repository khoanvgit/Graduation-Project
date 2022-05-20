using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;
using AdlezRestaurant.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdlezRestaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork db;

        public HomeController(ILogger<HomeController> logger, RMContext context)
        {
            _logger = logger;
            db = new UnitOfWork(context);
        }

        public IActionResult Index(string Alphabet, string Price)
        {
            if (Alphabet == SortOption.ASC)
            {
                ViewBag.isTopAlpha = true;
            }
            else if (Alphabet == SortOption.DESC)
            {
                ViewBag.isTopAlpha = false;
            }
            else
            {
                ViewBag.isTopAlpha = false;
            }

            if (Price == SortOption.High)
            {
                ViewBag.isHighPrice = true;
            }
            else if (Price == SortOption.Low)
            {
                ViewBag.isHighPrice = false;
            }
            else
            {
                ViewBag.isHighPrice = false;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Reservate(string CustomerName, string PhoneNumber, string Viproom, DateTime ReservedDate, int NumberOfPeople)
        {
            bool isVip = false;
            if (Viproom == "vip")
            {
                isVip = true;
            }

            if (CustomerName != null && PhoneNumber != null && NumberOfPeople != 0)
            {
                var table = GetRandomTable();

                if (table != 0)
                {
                    var reservation = new Reservation()
                    {
                        CustomerName = CustomerName,
                        PhoneNumber = PhoneNumber,
                        ReservedDate = DateTime.Now,
                        NumberOfPeople = NumberOfPeople,
                        Viproom = isVip,
                        TableNumber = table
                    };

                    db.Reservations.Add(reservation);
                    db.Tables.GetAll().Where(t => t.Status != TableStatus.Busy && t.Status != TableStatus.Reserved).FirstOrDefault(t => t.Number == table).Status = TableStatus.Wait;
                    db.Save();
                    ViewBag.msg = "Thank you for reserving, please arrive to restaurant in 30 minutes from now !";
                    return View(reservation);
                }
                else
                {
                    ViewBag.msg = "We are out of table right now, sorry for your convenience";
                }
                return View();
            }
            return RedirectToAction("Index");
        }

        private int GetRandomTable()
        {
            List<int> arr = new List<int>();
            foreach (var table in db.Tables.GetAll().ToList())
            {
                if (table.Status == TableStatus.Available)
                {
                    arr.Add(table.Number);
                }
            }
            if (arr.Count > 0)
            {
                return arr[0];
            }
            else if (arr.Count > 1)
            {
                Random random = new Random();
                while (true)
                {
                    int a = random.Next(1, 25);
                    foreach (int num in arr)
                    {
                        if (a == num)
                            return a;
                    }
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
