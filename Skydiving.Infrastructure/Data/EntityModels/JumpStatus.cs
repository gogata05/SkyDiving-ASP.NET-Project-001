using System.ComponentModel.DataAnnotations;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class JumpStatus
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Jump> Jumps { get; set; } = new List<Jump>();
    }
}
