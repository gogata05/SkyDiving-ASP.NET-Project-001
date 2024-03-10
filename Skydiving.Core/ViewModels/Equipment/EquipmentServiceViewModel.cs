using System.ComponentModel.DataAnnotations;

namespace Skydiving.Core.ViewModels.Equipment
{
    public class EquipmentServiceViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Title { get; set; } = null!;

        public string Brand { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

    }
}
