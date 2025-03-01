using BlogApp.Models;

namespace BlogApp.Repository
{
    public interface IAuthorRepository
    {
       List<Author> GetAllAuthors();
       Author GetAuthorByUsername(string username);
       void AddAuthor(Author author);
       void UpdateAuthor(Author author);
    }
}
