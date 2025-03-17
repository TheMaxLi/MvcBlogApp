using System;

namespace BlogApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorUsername { get; set; }
        public DateTime PublishedDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}