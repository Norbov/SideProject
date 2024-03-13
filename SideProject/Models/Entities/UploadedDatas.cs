using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SideProject.Models.Entities
{
    [Keyless]
    public class UploadedDatas
    {
        [ForeignKey("accounts")]
        public string username { get; set; }

        public virtual ApplicationUser aplicationUser { get; set; }

        public int imageId { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
