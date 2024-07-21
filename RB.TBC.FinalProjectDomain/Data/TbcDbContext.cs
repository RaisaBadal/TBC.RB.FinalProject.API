using Microsoft.EntityFrameworkCore;
using RB.TBC.FinalProject.Domain.Entitites;

namespace RB.TBC.FinalProject.Domain.Data
{
    public class TbcDbContext : DbContext
    {


        public TbcDbContext(DbContextOptions<TbcDbContext> ops) : base(ops)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VolumeInfo> VolumeInfos { get; set; }
        public DbSet<ImageLinks> ImageLinks { get; set; }
    }
}
