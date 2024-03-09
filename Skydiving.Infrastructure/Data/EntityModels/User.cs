using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class User : IdentityUser
    {
        [Required]
        public bool IsInstructor { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; } = null;

        [StringLength(50)]
        public string? LastName { get; set; } = null;
    }
}
