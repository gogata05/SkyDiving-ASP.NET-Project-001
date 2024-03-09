using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Brand { get; set; } = null!;

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        public int EquipmentCategoryId { get; set; }

        //[ForeignKey(nameof(EquipmentCategoryId))]
        //public EquipmentCategory Category { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; } = null!;

    }
}

