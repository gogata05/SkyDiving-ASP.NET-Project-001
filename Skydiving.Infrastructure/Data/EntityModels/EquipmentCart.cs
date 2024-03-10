using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class EquipmentCart
    {
        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;

        [Required]
        public int EquipmentId { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;
    }
}
