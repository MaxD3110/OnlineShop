using System.ComponentModel.DataAnnotations;

namespace Shop.UI.ViewModels.Admin
{
    public class CreateUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
