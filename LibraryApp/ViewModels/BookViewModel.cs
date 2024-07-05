using CoreBusiness;

namespace LibraryApp.ViewModels
{
    public class BookViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public Book Book { get; set; } = new Book();
    }
}
