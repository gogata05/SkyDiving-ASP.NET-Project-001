namespace Skydiving.Core.ViewModels
{
    public class JumpViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;//Address

        public string OwnerName { get; set; } = null!;

        public string OwnerId { get; set; }

        public DateTime StartDate { get; set; }

    }
}
