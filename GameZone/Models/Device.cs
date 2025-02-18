namespace GameZone.Models
{
    public class Device:BaseModel
    {
        public string Icon {  get; set; }

        public virtual ICollection<GameDevice> GameDevices { get; set; }
    }
}