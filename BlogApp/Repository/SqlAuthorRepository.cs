using BlogApp.Models;

namespace BlogApp.Repository
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private readonly BlogAppDbContext _context;

        public SqlAuthorRepository(BlogAppDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorByUsername(string username) => _context.Authors.FirstOrDefault(a => a.Username == username);

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}