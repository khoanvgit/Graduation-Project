using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AdlezRestaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(RMContext context, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = new UnitOfWork(context);
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Users.GetAll().Where(u => u.UserName != User.Identity.Name).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            await _userManager.DeleteAsync(user);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ResetEmployeePassword(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            return Redirect(HtmlEncoder.Default.Encode(callbackUrl) + $"&email={user.Email}");
        }
    }
}
