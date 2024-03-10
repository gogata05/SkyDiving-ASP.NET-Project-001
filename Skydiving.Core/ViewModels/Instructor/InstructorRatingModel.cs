using System.ComponentModel.DataAnnotations;

namespace Skydiving.Core.ViewModels.Instructor
{
    public class InstructorRatingModel
    {
        [Required]
        public string InstructorId { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int JumpId { get; set; }

        [StringLength(200)]
        public string? Comment { get; set; }

        [Required]
        [Range(1, 5)]
        [Display(Name = "selected stars")]
        public int Points { get; set; }
    }
}
