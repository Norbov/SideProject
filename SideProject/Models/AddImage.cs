using Microsoft.AspNetCore.Mvc;
using SideProject.Models.Entities;

namespace SideProject.Models
{
    public class AddImage
    {
        //public UploadedDatas uploader { get; set; }
        public fileFormat fileFormat { get; set; }
        //public byte[] image { get; set; }

        [BindProperty]
        public IFormFile file { get; set; }
    }
}
