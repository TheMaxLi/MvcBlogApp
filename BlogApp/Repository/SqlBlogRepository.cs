using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Repository
{
    public class SqlBlogRepository : IBlogRepository
    {
        private readonly BlogAppDbContext _context;

        public SqlBlogRepository(BlogAppDbContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogs() => _context.Blogs.Include(b => b.Comments).ToList();

        public Blog GetBlogById(int id) => _context.Blogs.Include(b => b.Comments).FirstOrDefault(b => b.Id == id);

        public void AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void UpdateBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        public void DeleteBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
        }

        public List<Blog> GetBlogsByAuthorUsername(string username)
        {
            return _context.Blogs.Where(b => b.AuthorUsername == username).ToList();
        }

        public void IncrementLikeCount(int blogId)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
            {
                blog.LikeCount++;
                _context.SaveChanges();
            }
        }

        public void AddComment(int blogId, Comment comment)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
            {
                blog.Comments.Add(comment);
                _context.SaveChanges();
            }
        }
    }
}