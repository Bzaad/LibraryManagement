using CoreBusiness;
using System.ComponentModel.DataAnnotations;


namespace LibraryApp.ViewModels
{
    public class TransactionsViewModel
    {
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}