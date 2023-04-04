using Biblioteca_MVC.Models;

namespace Biblioteca_MVC.ViewModels
{
	public class MemberBookLoansViewModel
	{
		public string NumeMembru { get; set; }
		//public string Title { get; set; }
		//public string Position { get; set; }
		public List<BookLoansModel>BookLoans = new List<BookLoansModel>();
	}
}
