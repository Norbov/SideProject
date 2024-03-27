using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SideProject.Models.Entities
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("accounts")]
        public string user { get; set; }

        [AllowNull]
        public virtual ApplicationUser applicationUser { get; set; }
    }
}
