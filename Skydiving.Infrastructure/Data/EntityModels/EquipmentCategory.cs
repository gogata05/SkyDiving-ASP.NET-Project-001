using System.ComponentModel.DataAnnotations;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class EquipmentCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
