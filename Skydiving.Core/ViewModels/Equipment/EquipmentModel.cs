using Skydiving.Core.ViewModels;
using Skydiving.Infrastructure.Data.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace Skydiving.Core.ViewModels.Equipment
{
    public class EquipmentModel
    {

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; } = null!;

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> EquipmentCategories { get; set; } = new List<CategoryViewModel>();

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Url]
        [StringLength(500, MinimumLength = 5)]
        public string? ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "10000")]
        public decimal Price { get; set; }
    }
}
