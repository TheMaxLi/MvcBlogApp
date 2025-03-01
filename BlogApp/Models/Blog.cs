using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        public string? AuthorUsername { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<string>? Tags { get; set; }
    }

}
