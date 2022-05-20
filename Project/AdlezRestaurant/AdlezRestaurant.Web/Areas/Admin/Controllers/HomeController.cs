using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Areas.Admin.ViewModels;
using AdlezRestaurant.Web.Const;
using AdlezRestaurant.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(RMContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        public IActionResult Index(int year)
        {
            var pays = _unitOfWork.Payments.GetAll().ToList();
            DateTime today = DateTime.Now;
            var todaySta = pays.Where(p => p.PaymentDate.ToShortDateString() == today.ToShortDateString()).ToList();
            var earningToday = todaySta.Select(p => p.TotalMoney).Sum();
            var customers = new List<int>();

            foreach (var item in todaySta.Select(p => p.OrderId))
            {
                customers.Add(_unitOfWork.Orders.GetEntity(item).CustomerId.Value);
            }

            Statistics sta = new Statistics()
            {
                Orders = todaySta.Count(),
                Customers = customers.Distinct().Count(),
                Revenue = earningToday.Value,
                BestSeller = "..."
            };

            // Reservation count
            ViewBag.reservationCount = _unitOfWork.Tables.GetAll().Where(r => r.Status == TableStatus.Wait).Count();

            // For chart
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            var revenues = new List<decimal>();
            foreach (var item in months)
            {
                revenues.Add(pays.Where(p => p.PaymentDate.ToString("MMM", CultureInfo.InvariantCulture) == item && p.PaymentDate.Year == year).Select(p => p.TotalMoney.Value).Sum());
            }
            ViewBag.months = months;
            ViewBag.revenues = revenues;
            ViewBag.totalYearRevenue = pays.Where(p => p.PaymentDate.Year == year).Select(p => p.TotalMoney.Value).Sum().ToString("C2");
            TempData["choosenYear"] = year;

            // For TOP 5
            var dishList = new List<int>();
            foreach (var pay in pays)
            {
                var ods = _unitOfWork.OrderDetails.GetAll().Where(od => od.OrderId == pay.OrderId).ToList();
                foreach (var dish in ods)
                {
                    dishList.Add(dish.DishId);
                }
            }
            var dishes = dishList.GroupBy(d => d);
            var top5 = dishes.OrderByDescending(d => d.Count()).Take(5).ToList();
            ViewBag.top5 = top5.Select(t => t.Key).ToList();
            int totalCount = 0;
            foreach(var item in top5)
            {
                totalCount += item.Count();
            }

            foreach(var dish in top5)
            {
                ViewData[$"name{dish.Key}"] = _unitOfWork.Dishes.GetEntity(dish.Key).Name;
                ViewData[$"percent{dish.Key}"] = ((dish.Count() / Convert.ToDouble(totalCount))*100).ToString("N1");
            }

            return View(sta);
        }

        public IActionResult GreatYear()
        {
            var pays = _unitOfWork.Payments.GetAll().ToList();
            var minYear = pays.Select(p => p.PaymentDate).Min().Year;
            var maxYear = pays.Select(p => p.PaymentDate).Max().Year;
            var revenues = new Dictionary<int, decimal>();
            for (int i = minYear; i <= maxYear; i++)
            {
                revenues.Add(i, pays.Where(p => p.PaymentDate.Year == i).Select(p => p.TotalMoney.Value).Sum());
            }

            var greatYear = revenues.FirstOrDefault(r => r.Value == revenues.Max(kvp => kvp.Value)).Key;

            return RedirectToAction("Index", new { year = greatYear });
        }

        public IActionResult SpecificTimeByDate(DateTime searchDate)
        {
            var pays = _unitOfWork.Payments.GetAll().ToList();
            StringBuilder sb = new StringBuilder();
            string formatDate = searchDate.ToShortDateString();
            var todaySta = new List<Payment>();
            var dishList = new List<int>();
            foreach (var pay in pays)
            {
                sb.Append(pay.PaymentDate.ToShortDateString());
                if (sb.ToString() == formatDate)
                {
                    todaySta.Add(pay);
                    var ods = _unitOfWork.OrderDetails.GetAll().Where(od => od.OrderId == pay.OrderId).ToList();
                    foreach (var dish in ods)
                    {
                        dishList.Add(dish.DishId);
                    }
                }
                sb.Clear();
            }
            if (todaySta.Count() > 0)
            {
                var dishIds = dishList.GroupBy(d => d);
                var bestSellerId = dishIds.FirstOrDefault(d => d.Count() == dishIds.Select(kvp => kvp.Count()).Max()).Key;
                var earningToday = todaySta.Select(p => p.TotalMoney).Sum();
                var customers = new List<int>();
                foreach (var item in todaySta.Select(p => p.OrderId))
                {
                    customers.Add(_unitOfWork.Orders.GetEntity(item).CustomerId.Value);
                }

                Statistics sta = new Statistics()
                {
                    Orders = todaySta.Count(),
                    Customers = customers.Distinct().Count(),
                    Revenue = earningToday.Value,
                    BestSeller = _unitOfWork.Dishes.GetEntity(bestSellerId).Name
                };

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "StatisticReport", sta) });
            }
            else
            {
                Statistics sta = new Statistics()
                {
                    Orders = 0,
                    Customers = 0,
                    Revenue = 0,
                    BestSeller = "None"
                };
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "StatisticReport", sta) });
            }
        }

        public IActionResult SpecificTimeByMonth(DateTime searchMonth)
        {
            var pays = _unitOfWork.Payments.GetAll().ToList();
            StringBuilder sb = new StringBuilder();
            int month = searchMonth.Month;
            int year = searchMonth.Year;
            string formatDate = searchMonth.Month + "-" + searchMonth.Year;
            var todaySta = new List<Payment>();
            var dishList = new List<int>();
            foreach (var pay in pays)
            {
                sb.Append(pay.PaymentDate.Month + "-" + pay.PaymentDate.Year);
                if (sb.ToString() == formatDate)
                {
                    todaySta.Add(pay);
                    var ods = _unitOfWork.OrderDetails.GetAll().Where(od => od.OrderId == pay.OrderId).ToList();
                    foreach (var dish in ods)
                    {
                        dishList.Add(dish.DishId);
                    }
                }
                sb.Clear();
            }
            if (todaySta.Count() > 0)
            {
                var dishIds = dishList.GroupBy(d => d);
                var bestSellerId = dishIds.FirstOrDefault(d => d.Count() == dishIds.Select(kvp => kvp.Count()).Max()).Key;
                var earningToday = todaySta.Select(p => p.TotalMoney).Sum();
                var customers = new List<int>();
                foreach (var item in todaySta.Select(p => p.OrderId))
                {
                    customers.Add(_unitOfWork.Orders.GetEntity(item).CustomerId.Value);
                }

                Statistics sta = new Statistics()
                {
                    Orders = todaySta.Count(),
                    Customers = customers.Distinct().Count(),
                    Revenue = earningToday.Value,
                    BestSeller = _unitOfWork.Dishes.GetEntity(bestSellerId).Name
                };

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "StatisticReport", sta) });
            }
            else
            {
                Statistics sta = new Statistics()
                {
                    Orders = 0,
                    Customers = 0,
                    Revenue = 0,
                    BestSeller = "None"
                };
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "StatisticReport", sta) });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
