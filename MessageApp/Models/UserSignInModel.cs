using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MessageApp.Models
{
    public class UserSignInModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}
