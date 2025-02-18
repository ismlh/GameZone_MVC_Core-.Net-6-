

namespace GameZone.Models
{
    public class Game : BaseModel
    {
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


       

        public virtual ICollection<GameDevice> GameDevices { get; set; }
    }
}
