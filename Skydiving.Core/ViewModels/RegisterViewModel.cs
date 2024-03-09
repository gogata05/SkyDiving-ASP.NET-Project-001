using System.ComponentModel.DataAnnotations;
using static Skydiving.Core.Constants.UserConstants.AppUserConstants;
namespace Skydiving.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
