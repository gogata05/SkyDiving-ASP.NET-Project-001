using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Skydiving.Infrastructure.Data.DataConstants.EntityConstants.User;
namespace Skydiving.Infrastructure.Data.EntityModels
{
    public class User : IdentityUser
    {
        [Required]
        public bool IsInstructor { get; set; }

        [StringLength(UserFirstNameMaxLength)]
        public string? FirstName { get; set; } = null;

        [StringLength(UserLastNameMaxLength)]
        public string? LastName { get; set; } = null;
    }
}
