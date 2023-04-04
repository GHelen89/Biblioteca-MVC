using Biblioteca_MVC.DataContext;
using Biblioteca_MVC.Models;
using Biblioteca_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;



namespace Biblioteca_MVC.Repositories
{
    public class BooksRepository
    {
        private readonly BibliotecaDBDataContext _context;

        public BooksBookLoansViewModel GetBooksBookLoans(Guid memberID)
        {
            BooksBookLoansViewModel booksBookLoansViewModel = new BooksBookLoansViewModel();
            BooksModel member = _context.Books.FirstOrDefault(x => x.IDCarte == memberID);
            if (member != null)
            {
                booksBookLoansViewModel.NumeCarte = member.NumeCarte;
                //memberBookLoansViewModel.Position = member.Position;
                //memberBookLoansViewModel.Title = member.Title;
                IQueryable<BookLoansModel> booksBookLoans = _context.BookLoans.Where(x => x.IDCarte == memberID);
                foreach (BookLoansModel dbBookLoans in booksBookLoans)
                {
                    booksBookLoansViewModel.BookLoans.Add(dbBookLoans);
                }
            }
            return booksBookLoansViewModel;
        }
        public BooksRepository (BibliotecaDBDataContext context)
        {
            _context = context;
        }
        public DbSet<BooksModel> GetBooks()
        {
            return _context.Books;
        }
        public void Add (BooksModel model)
        {
            model.IDCarte = Guid.NewGuid();
            _context.Books.Add(model);
            _context.SaveChanges();
        }
        public BooksModel  GetBooksById(Guid Id)
        {
            BooksModel book = _context.Books.FirstOrDefault(x => x.IDCarte == Id);

            return book;
        }
        public void Update (BooksModel model)
        {
            _context.Books.Update(model);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            BooksModel book = GetBooksById(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
