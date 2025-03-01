using BlogApp.Models;
using BlogApp.Models.ViewModels;
using BlogApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBlogRepository _blogRepository;
        public AuthorController(IAuthorRepository authorRepository, IBlogRepository blogRepository)
        {
            _authorRepository = authorRepository;
            _blogRepository = blogRepository;
        }

        public IActionResult Index(string searchString)
        {
            var authors = _authorRepository.GetAllAuthors();
            ViewData["PageTitle"] = "Authors";
            ViewBag.TotalAuthors = authors.Count;

            if (!string.IsNullOrEmpty(searchString))
            {
                authors = authors.FindAll((a) => a.Username.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(authors);
        }

        public IActionResult Details(string username)
        {
            var author = _authorRepository.GetAuthorByUsername(username);
            if (author == null)
                return NotFound();

            var blogs = _blogRepository.GetBlogsByAuthorUsername(username);
            ViewBag.AuthorUsername = username;
            return View(blogs);
        }
    }
}
