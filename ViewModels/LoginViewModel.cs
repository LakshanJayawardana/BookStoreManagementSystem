using System.ComponentModel.DataAnnotations;
namespace WebApplication1.ViewModels;

    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
    }
