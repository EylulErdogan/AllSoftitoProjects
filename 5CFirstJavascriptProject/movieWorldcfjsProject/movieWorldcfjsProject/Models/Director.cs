using System.ComponentModel.DataAnnotations;

namespace movieWorldcfjsProject.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "isim giriniz")]
        public string FullName { get; set; }

    }
}
