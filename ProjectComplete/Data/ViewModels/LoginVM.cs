using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Введите Email")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
