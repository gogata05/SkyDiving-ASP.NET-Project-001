using System.ComponentModel.DataAnnotations;

namespace Skydiving.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
