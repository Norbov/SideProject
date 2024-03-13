using System.ComponentModel.DataAnnotations;

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
    }
}
