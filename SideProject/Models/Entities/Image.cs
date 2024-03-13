using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SideProject.Models.Entities
{
    public enum fileFormat { pdf, png }
    public class Image
    {
        [Key]
        public int Id { get; set; }

        //public UploadedDatas uploader { get; set; }
        public fileFormat fileFormat { get; set; }
        public byte[] image { get; set; }

        [ForeignKey("accounts")]
        public string user { get; set; }

        public virtual ApplicationUser applicationUser { get; set; }
    }
}
