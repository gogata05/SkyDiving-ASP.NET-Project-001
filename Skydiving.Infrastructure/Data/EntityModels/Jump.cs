using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Jump
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        public int JumpCategoryId { get; set; }

        [ForeignKey(nameof(JumpCategoryId))]
        public JumpCategory Category { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;//Address

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } = null!;

        [StringLength(50)]
        public string? OwnerName { get; set; }

        public string? InstructorId { get; set; }

        [Required]
        public bool IsTaken { get; set; }

        [Required]
        public bool IsActive { get; set; } = false;
        //[Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int JumpStatusId { get; set; } = 1;


    }
}
