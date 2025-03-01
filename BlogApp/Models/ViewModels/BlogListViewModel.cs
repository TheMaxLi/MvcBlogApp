namespace BlogApp.Models.ViewModels
{
    public class BlogListViewModel
    {
        public List<Blog> Blogs { get; set; }
        public string CurrentFilter { get; set; }
        public int TotalPosts { get; set; }
    }
}
