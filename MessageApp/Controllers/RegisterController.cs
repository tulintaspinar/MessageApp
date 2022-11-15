using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
