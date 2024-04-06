using System.ComponentModel.DataAnnotations;
using static Skydiving.Infrastructure.Data.DataConstants.EntityConstants.Rating;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string InstructorId { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int JumpId { get; set; }

        [StringLength(RatingCommentMaxLength)]
        public string? Comment { get; set; }

        [Required]
        [Range(RatingPointsMinLength, RatingPointsMaxLength)]
        public int Points { get; set; }

    }
}
