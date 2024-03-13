using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SideProject.Models.Entities
{
    public class ApplicationUser /*: IdentityUser<int>*/
    {
        [Key]
        public string userName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

        public string Role { get; set; }


        //public virtual ICollection<IdentityUserRole<int>> Roles { get; } = new List<IdentityUserRole<int>>();
    }
}
