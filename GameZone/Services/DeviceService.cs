
namespace GameZone.Services
{
    public class DeviceService : Repository<Device>, IDeviceService
    {
        public DeviceService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
