using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;

namespace RestaurantManagement.ViewComponents
{
    public class DishMenu : ViewComponent
    {
        private readonly IUnitOfWork db;
        public DishMenu(RMContext context)
        {
            db = new UnitOfWork(context);
        }

        public async Task<IViewComponentResult> InvokeAsync(string Alphabet, string Price)
        {
            var dishes = db.Dishes.GetAll().Include(d => d.DishType).ToList();
            if (Alphabet == SortOption.DESC)
            {
                dishes = db.Dishes.GetAll().Include(d => d.DishType).OrderByDescending(d => d.Name).ToList();
            }
            if (Price == SortOption.Low)
            {
                dishes = db.Dishes.GetAll().Include(d => d.DishType).OrderBy(d => d.Price).ToList();
            }
            if (Alphabet == SortOption.ASC && Price == SortOption.High)
            {
                dishes = db.Dishes.GetAll().Include(d => d.DishType).OrderBy(d => d.Name).ThenByDescending(d => d.Price).ToList();
            }
            if (Alphabet == SortOption.ASC && Price == "")
            {
                dishes = db.Dishes.GetAll().Include(d => d.DishType).OrderBy(d => d.Name).ToList();
            }
            if (Alphabet == "" && Price == SortOption.High)
            {
                dishes = db.Dishes.GetAll().Include(d => d.DishType).OrderByDescending(d => d.Price).ToList();
            }
            
            return await Task.FromResult((IViewComponentResult)View("Default", dishes));
        }
    }
}
