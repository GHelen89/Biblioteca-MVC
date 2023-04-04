using Biblioteca_MVC.Models;

namespace Biblioteca_MVC.ViewModels
{
    public class BooksBookLoansViewModel
    {
        public string NumeCarte { get; set; }
        //public string Title { get; set; }
        //public string Position { get; set; }
        public List<BookLoansModel> BookLoans = new List<BookLoansModel>();
    }
}
