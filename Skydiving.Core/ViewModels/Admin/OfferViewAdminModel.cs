using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Core.ViewModels.Admin
{
    public class OfferViewAdminModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public List<User> Owner { get; set; } = new List<User>();

        [Required]
        public string OwnerId { get; set; } //null!; 
                                            // or int and add instructor entity
        [Required]
        public decimal Price { get; set; }
        //time

        public bool? IsAccepted { get; set; } = null;

        public IEnumerable<JumpOffer> JumpsOffers { get; set; } = new List<JumpOffer>();
    }
}
