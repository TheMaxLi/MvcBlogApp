using BlogApp.Models.ViewModels;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Repository;
using Microsoft.Extensions.Hosting;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IAuthorRepository _authorRepository;


        public BlogController(IBlogRepository blogRepository, IAuthorRepository authorRepository)
        {
            _blogRepository = blogRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            var blogs = _blogRepository.GetAllBlogs();
            ViewData["PageTitle"] = "Blog Listings";
            ViewBag.TotalPosts = blogs.Count;

            var viewModel = new BlogListViewModel
            {
                Blogs = blogs,
                TotalPosts = blogs.Count,
                CurrentFilter = ""
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authorUsername = HttpContext.Session.GetString("AuthorUsername");
            if (string.IsNullOrEmpty(authorUsername))
            {
                return RedirectToAction("LoginRegister", "Session");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            var authorUsername = HttpContext.Session.GetString("AuthorUsername");
            if (string.IsNullOrEmpty(authorUsername))
            {
                return RedirectToAction("LoginRegister", "Session");
            }

            if (ModelState.IsValid)
            {
                blog.AuthorUsername = authorUsername;
                blog.PublishedDate = DateTime.Now;
                blog.Tags = new List<string> { };
                _blogRepository.AddBlog(blog);
                return RedirectToAction("Index");
            }

            return View(blog);
        }
    }
}
