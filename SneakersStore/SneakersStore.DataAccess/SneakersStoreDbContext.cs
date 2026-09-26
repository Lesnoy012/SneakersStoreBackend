using Microsoft.EntityFrameworkCore;
using SneakersStore.DataAccess.Entites;

namespace SneakersStore.DataAccess
{
    public class SneakersStoreDbContext : DbContext
    {
        public SneakersStoreDbContext(DbContextOptions<SneakersStoreDbContext> options) : base(options){}

        public DbSet<SneakersEntity> Sneakers { get; set; }
    }
}
