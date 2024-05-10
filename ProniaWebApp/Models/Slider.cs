using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaWebApp.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Duzgun daxil edin!")]
        public string Title { get; set; }
        [StringLength(50,ErrorMessage ="Cox uzatma)")]
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }


    }
}
