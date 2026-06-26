using System.ComponentModel.DataAnnotations;

namespace movieWorldcfjsProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "isim giriniz")]
        public string Name { get; set; }
    }
}
