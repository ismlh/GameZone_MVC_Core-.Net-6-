namespace GameZone.Models
{
    public class Category:BaseModel
    {
        public virtual IEnumerable<Game> Games { get; set; }
    }
}