using BlogApp.Models;

namespace BlogApp.Repository
{
    public interface IBlogRepository
    {
        List<Blog> GetAllBlogs();
        Blog GetBlogById(int id);
        void AddBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog(int id);
        List<Blog> GetBlogsByAuthorUsername(string username);
        void AddComment(int id, Comment comment);
        void IncrementLikeCount(int id);

    }
}
