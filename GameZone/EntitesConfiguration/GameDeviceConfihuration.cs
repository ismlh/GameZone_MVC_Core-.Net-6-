using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.EntitesConfiguration
{
    public class GameDeviceConfihuration
    
        : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(b => new { b.DeviceId, b.GameId });
            

            builder
                .HasOne(gd => gd.Game)
                .WithMany(g => g.GameDevices)
                .HasForeignKey(gd => gd.GameId);

            builder
                .HasOne(gd => gd.Device)
                .WithMany(d => d.GameDevices)
                .HasForeignKey(gd => gd.DeviceId);
        }
    }
}
