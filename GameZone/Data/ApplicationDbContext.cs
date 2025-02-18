

namespace GameZone.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameDeviceConfihuration());
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<GameDevice> GameDevices { get; set; }

    }
}
