using Microsoft.AspNetCore.Identity;

namespace MagicVilla_VillaApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
    }
}
