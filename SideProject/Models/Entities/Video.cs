using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SideProject.Models.Entities
{
    public class Video : Relation
    {
        public fileFormat fileFormat { get; set; }
        public byte[] video { get; set; }

    }
}
