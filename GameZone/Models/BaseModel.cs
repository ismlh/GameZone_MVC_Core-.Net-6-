
namespace GameZone.Models
{
    public class BaseModel
    {

        public int Id { get; set; }
        [MaxLength(100),MinLength(2)]
        public string Name { get; set; }=string.Empty;
    }
}
