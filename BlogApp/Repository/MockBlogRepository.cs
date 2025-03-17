using BlogApp.Models;

namespace BlogApp.Repository
{
    public class MockBlogRepository : IBlogRepository
    {
        private List<Blog> _blogs;

        public MockBlogRepository()
        {
            _blogs = new List<Blog>
        {
            new Blog
            {
                Id = 1,
                Title = "First Blog Post",
                Content = "This is the content of first blog post",
                AuthorUsername = "Test 1",
                PublishedDate = DateTime.Now.AddDays(-5),
                Tags = new List<string> { "Technology", "Programming" },
            },
        };
        }

        public List<Blog> GetAllBlogs() => _blogs;
        public Blog GetBlogById(int id) => _blogs.FirstOrDefault(b => b.Id == id);
        public void AddBlog(Blog blog)
        {
            blog.Id = _blogs.Max(b => b.Id) + 1;
            _blogs.Add(blog);
        }
        public void UpdateBlog(Blog blog)
        {
            var existingBlog = _blogs.FirstOrDefault(b => b.Id == blog.Id);
            if (existingBlog != null)
            {
                _blogs.Remove(existingBlog);
                _blogs.Add(blog);
            }
        }
        public void DeleteBlog(int id)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
                _blogs.Remove(blog);
        }
        public List<Blog> GetBlogsByAuthorUsername(string username)
        {
            return _blogs.FindAll((b) => b.AuthorUsername == username);
        }
        public void IncrementLikeCount(int blogId)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
                blog.LikeCount++;
        }
        public void AddComment(int blogId, Comment comment)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
                blog.Comments.Add(comment);
        }
    }
}
