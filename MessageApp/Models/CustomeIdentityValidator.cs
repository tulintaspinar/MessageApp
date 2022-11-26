using Microsoft.AspNetCore.Identity;

namespace MessageApp.Models
{
    public class CustomeIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code= "PasswordTooShort",
                Description=$"Şifre en az {length} uzunluğunda olmalıdır."
            };
        }
    }
}
