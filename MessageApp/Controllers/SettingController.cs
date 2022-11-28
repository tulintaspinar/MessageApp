using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using MessageApp.BusinessLayer.Abstract;
using MessageApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace MessageApp.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageManager;

        public SettingController(UserManager<AppUser> userManager, IMessageService messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserPhoto = result.ImageUrl;
            UserEditViewModel user = new UserEditViewModel();
            user.Name = result.Name;
            user.Surname = result.Surname;
            user.Email = result.Email;
            user.Phone = result.PhoneNumber;
            user.ImageUrl = result.ImageUrl;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> GeneralSetting(UserEditViewModel userEditView)
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditView.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditView.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditView.Image.CopyToAsync(stream);
                result.ImageUrl = imageName;
            }

            result.Name = userEditView.Name;
            result.Surname = userEditView.Surname;
            result.Email = userEditView.Email;
            result.PhoneNumber = userEditView.Phone;

            var updateUser = await _userManager.UpdateAsync(result);
            if (updateUser.Succeeded)
                return RedirectToAction("Settings", "Setting");
            else
            {
                ModelState.AddModelError("", "Bilgileriniz güncellenemedi.");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PasswordSetting(UserEditViewModel userEditView)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (userEditView.NewPassword == userEditView.ConfirmNewPassword)
            {
                var updateUser = await _userManager.ResetPasswordAsync(user, token, userEditView.NewPassword);
                if (updateUser.Succeeded)
                    return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Bilgileriniz güncellenemedi.");
            }
            return RedirectToAction("Settings", "Setting");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                return RedirectToAction("Settings", "Setting");
            }
        }
    }
}
