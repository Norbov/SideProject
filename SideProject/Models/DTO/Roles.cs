using Microsoft.AspNetCore.Identity;

namespace SideProject.Models.DTO
{
    public class Roles : IdentityRole<int>
    {
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";
    }
}
