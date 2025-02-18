namespace GameZone.Models
{
    public class GameDevice
    {
      
            public int GameId { get; set; } // Foreign key to Game
            public int DeviceId { get; set; } // Foreign key to Device

            // Navigation properties
            public virtual Game Game { get; set; }
            public virtual Device Device { get; set; }
    }
}
