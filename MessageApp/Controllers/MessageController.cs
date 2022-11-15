using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Chats()
        {
            return View();
        }
        public IActionResult Group()
        {
            return View();
        }
        public IActionResult Status()
        {
            return View();
        }
        public IActionResult Calls()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
    }
}
