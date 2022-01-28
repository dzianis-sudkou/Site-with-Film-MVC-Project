using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Введите своё имя")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm your password:")]
        [Required(ErrorMessage = "Необходим повторный ввод пароля")]
       
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string CofirmPassword { get; set; }
    }
}
