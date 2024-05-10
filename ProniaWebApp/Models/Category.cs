using System.ComponentModel.DataAnnotations;

namespace ProniaWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Duzgun daxil edin!")]

        public string Name { get; set; } = null!;
        public List<Product>? Products { get; set; }
    }
}
