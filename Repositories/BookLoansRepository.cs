using Biblioteca_MVC.DataContext;
using Biblioteca_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_MVC.Repositories
{
    public class BookLoansRepository
    {
        private readonly BibliotecaDBDataContext _context;
        public BookLoansRepository(BibliotecaDBDataContext context)
        {
            _context = context;
        }
        public DbSet<BookLoansModel> GetBookLoans()
        {
            return _context.BookLoans;
        }
        public void Add(BookLoansModel model)
        {
            model.IDCarte = Guid.NewGuid();
            _context.BookLoans.Add(model);
            _context.SaveChanges();
        }
        public BookLoansModel GetBookLoansById(Guid Id)
        {
            BookLoansModel book = _context.BookLoans.FirstOrDefault(x => x.IDImprumut == Id);

            return book;
        }
        public void Update(BookLoansModel model)
        {
            _context.BookLoans.Update(model);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            BookLoansModel book = GetBookLoansById(id);
            _context.BookLoans.Remove(book);
            _context.SaveChanges();
        }
    }
}
