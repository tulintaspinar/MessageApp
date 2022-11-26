using Microsoft.AspNetCore.Http;

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
    }
}
