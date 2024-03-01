using System.ComponentModel.DataAnnotations;

namespace SideProject.Models.Entities
{
    public class ApplicationUser
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
