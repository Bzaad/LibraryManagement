using LibraryApp.Models;

namespace LibraryApp.ViewModels
{
    public class UserConsoleViewModel
    {
        public int SelectedCategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }  = new List<Category>();
    }
}
