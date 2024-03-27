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

        public List<int> imageIds { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public List<int> videIds { get; set; }

        public virtual ICollection<Video> Video { get; set; }
    }
}
