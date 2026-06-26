using System.ComponentModel.DataAnnotations;

namespace movieWorldcfjsProject.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "baslık giriniz")]

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int ReleaseYear { get; set; }
        public decimal Imdb { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

    }
}
