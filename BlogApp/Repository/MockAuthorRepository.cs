using BlogApp.Models;

namespace BlogApp.Repository
{
    public class MockAuthorRepository: IAuthorRepository
    {
        private List<Author> _authors;

        public MockAuthorRepository()
        {
            _authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Username = "Test 1",
                Password = "123",
            }
        };
        }

        public List<Author> GetAllAuthors() => _authors;
        public Author GetAuthorByUsername(string username) => _authors.FirstOrDefault(b => b.Username == username);
        public void AddAuthor(Author author)
        {
            author.Id = _authors.Max(b => b.Id) + 1;
            _authors.Add(author);
        }
        public void UpdateAuthor(Author author)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                _authors.Remove(existingAuthor);
                _authors.Add(author);
            }
        }


    }
}
