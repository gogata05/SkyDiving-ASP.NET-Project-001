using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public IEnumerable<EquipmentCart> EquipmentsCarts = new List<EquipmentCart>();

        //public bool Is { get; set; }
    }
}
