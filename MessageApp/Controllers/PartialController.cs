using MessageApp.BusinessLayer.Abstract;
using MessageApp.BusinessLayer.Concrete;
using MessageApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MessageApp.Controllers
{
    public class PartialController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageManager;

        public PartialController(UserManager<AppUser> userManager, IMessageService messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        }
        public IActionResult AddContactPartial()
        {
            return View();
        }
        public async Task<PartialViewResult> ListMessagePartial()
        {
            return PartialView();
        }
    }
}
