using System.ComponentModel.DataAnnotations;
using static Skydiving.Infrastructure.Data.DataConstants.EntityConstants.EquipmentCategory;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class EquipmentCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EquipmentCategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
