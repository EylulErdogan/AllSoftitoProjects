namespace movieWorldcfjsProject.Models
{
    public class MovieCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Imdb { get; set; }

        public int? CategoryId { get; set; }
        public string NewCategoryName { get; set; }

        public int? DirectorId { get; set; }
        public string NewDirectorName { get; set; }
    }
}
