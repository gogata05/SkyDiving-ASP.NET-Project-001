using System.ComponentModel.DataAnnotations;

namespace Skydiving.Core.ViewModels.Instructor
{
    public class BecomeInstructorViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 7)]
        [Display(Name = "Phone number")]
        [Phone] //validate phone number?
        public string PhoneNumber { get; set; } = null!;

    }
}
