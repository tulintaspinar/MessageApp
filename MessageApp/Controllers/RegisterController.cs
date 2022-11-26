using MessageApp.BusinessLayer.Concrete;
using MessageApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MessageApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser,appUser.PasswordHash);
            if (result.Succeeded)
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}
