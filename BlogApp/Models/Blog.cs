
namespace BlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? AuthorUsername { get; set; }
        public DateTime PublishedDate { get; set; }
        public int LikeCount { get; set; } // New property
        public List<Comment> Comments { get; set; } = new List<Comment>(); // New property
        public List<string> Tags { get; set; } = new List<string>();
    }
}