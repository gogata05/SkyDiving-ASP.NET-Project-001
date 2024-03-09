using System.ComponentModel.DataAnnotations;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class JumpCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<Jump> Jumps { get; set; } = new List<Jump>();
    }
}
