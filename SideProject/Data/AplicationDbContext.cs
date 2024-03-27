using Microsoft.EntityFrameworkCore;
using SideProject.Models.Entities;


namespace SideProject.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<User> users { get; set; }
        public DbSet<ApplicationUser> accounts { get; set; }
        //Relation table, depend on how foreign keys work, that it is needed or not
        //public DbSet<UploadedDatas> uploads { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Video> videos { get; set; }
    }
}
