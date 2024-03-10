namespace Skydiving.Core.ViewModels.Offer
{
    public class OfferServiceViewModel : OfferViewModel
    {
        public int Id { get; set; }

        public string Rating { get; set; } = null!;

        public string InstructorName { get; set; } = null!;

        public string InstructorPhoneNumber { get; set; } = null!;

        public string JumpTitle { get; set; } = null!;

        public string JumpDescription { get; set; } = null!;

        public string JumpCategory { get; set; } = null!;

        public bool? IsAccepted { get; set; }
    }
}
