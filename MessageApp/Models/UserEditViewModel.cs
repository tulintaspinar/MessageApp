using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MessageApp.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Lütfen mevcut şifrenizi giriniz!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Yeni şifrenizi giriniz!")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifrenizi tekrar giriniz!")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor. Lütfen tekrar giriniz!")]
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
    }
}
