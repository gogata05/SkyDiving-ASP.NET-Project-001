using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class JumpOffer
    {
        [Required]
        public int JumpId { get; set; }

        [ForeignKey(nameof(JumpId))]
        public Jump Jump { get; set; } = null!;

        [Required]
        public int OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; } = null!;
    }
}
