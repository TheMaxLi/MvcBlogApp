namespace BlogApp.Models.ViewModels
{
    public class AuthorListViewModel
    {
        public List<Author> Authors { get; set; }
        public string CurrentSearch { get; set; }
        public int TotalAuthors { get; set; }
    }
}
