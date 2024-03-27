using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SideProject.Models.Entities
{
    public enum fileFormat { pdf, png }
    public class Image : Relation
    {
        public fileFormat fileFormat { get; set; }
        public byte[] image { get; set; }
    }
}
