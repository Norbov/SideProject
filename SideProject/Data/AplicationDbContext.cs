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
        public DbSet<UploadedDatas> uploads { get; set; }
        public DbSet<Image> images { get; set; }
    }
}
