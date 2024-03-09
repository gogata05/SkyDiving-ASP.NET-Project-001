namespace Skydiving.Core.ViewModels
{
    public class MyJumpViewModel
    {
        public int Id { get; set; }

        public string OwnerId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsTaken { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsApproved { get; set; } = false;

        public string Status { get; set; } = null!;

        public string? InstructorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
