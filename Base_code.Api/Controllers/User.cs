using System.ComponentModel.DataAnnotations;

namespace Base_code.Api.Controllers
{
    public class User
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
