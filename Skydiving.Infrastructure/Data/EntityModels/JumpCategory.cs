using System.ComponentModel.DataAnnotations;
using static Skydiving.Infrastructure.Data.DataConstants.EntityConstants.JumpCategory;
namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class JumpCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(JumpCategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Jump> Jumps { get; set; } = new List<Jump>();
    }
}
