using System.ComponentModel.DataAnnotations;

namespace SideProject.Models
{
    public class SignUpModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Compare("comfirmPassword")]
        public string password { get; set; }
        [Required]
        public string comfirmPassword { get; set; }
    }
}
