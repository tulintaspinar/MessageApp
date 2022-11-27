using MessageApp.BusinessLayer.Concrete;
using MessageApp.EntityLayer.Concrete;
using MessageApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MessageApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInModel appUser)
        {
            var result = await _userManager.PasswordSignInAsync(appUser.UserName, appUser.Password, true, true);
            if (result.Succeeded)
                return RedirectToAction("Chats", "Message");
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
//tulin tuliN123*
//cihan cihaN123*