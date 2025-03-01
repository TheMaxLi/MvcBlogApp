using BlogApp.Models;
using BlogApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class SessionController : Controller
{
    private readonly IAuthorRepository _authorRepository;

    public SessionController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public IActionResult LoginRegister()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var author = _authorRepository.GetAuthorByUsername(username);
        if (author != null && author.Password == password) 
        {
            HttpContext.Session.SetString("AuthorUsername", username); 
            return RedirectToAction("Index", "Blog");
        }
        ModelState.AddModelError("", "Invalid username or password.");
        return View("LoginRegister");
    }

    [HttpPost]
    public IActionResult Register(string username, string password)
    {
        if (_authorRepository.GetAuthorByUsername(username) != null)
        {
            ModelState.AddModelError("", "Username already exists.");
            return View("LoginRegister");
        }

        var newAuthor = new Author
        {
            Username = username,
            Password = password 
        };
        _authorRepository.AddAuthor(newAuthor);

        HttpContext.Session.SetString("AuthorUsername", username); 
        return RedirectToAction("Index", "Blog");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AuthorUsername"); 
        return RedirectToAction("Index", "Blog");
    }
}