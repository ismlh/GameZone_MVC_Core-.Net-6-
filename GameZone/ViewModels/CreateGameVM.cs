using System.Text.RegularExpressions;

namespace GameZone.ViewModels
{
    public class CreateGameVM
    {
        [MaxLength(100), MinLength(2)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile Cover { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Devices")]

        public List<int> SelectedDevices { get; set; }
    }
}
