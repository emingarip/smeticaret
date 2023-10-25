using System.ComponentModel.DataAnnotations;

namespace smeticaret.webapi.Models
{
    public class LoginModel
    {
        [Required,MinLength(1),EmailAddress]
        public string email { get; set; }
        public string password { get; set; }

    }
}
