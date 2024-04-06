using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Skydiving.Infrastructure.Data.DataConstants.EntityConstants.Equipment;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EquipmentTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(EquipmentBrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [Range(EquipmentQuantityMinLength, EquipmentQuantityMaxLength)]
        public int Quantity { get; set; }

        [Required]
        public int EquipmentCategoryId { get; set; }

        [ForeignKey(nameof(EquipmentCategoryId))]
        public EquipmentCategory Category { get; set; } = null!;

        [Required]
        [StringLength(EquipmentDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Required]
        [Precision(EquipmentPriceMaxLength, EquipmentPriceMinLength)]
        public decimal Price { get; set; }

        [StringLength(EquipmentImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<EquipmentCart> EquipmentsCarts { get; set; } = new List<EquipmentCart>();
    }
}

