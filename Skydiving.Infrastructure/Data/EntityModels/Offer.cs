using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public bool? IsAccepted { get; set; } = null;

        public IEnumerable<JumpOffer> JumpsOffers { get; set; } = new List<JumpOffer>();

        [Required]
        public bool IsActive { get; set; } = true;

    }
}
