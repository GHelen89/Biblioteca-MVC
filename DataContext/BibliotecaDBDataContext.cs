using System.Collections.Generic;
using Biblioteca_MVC.Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca_MVC.DataContext
{
    public class BibliotecaDBDataContext :DbContext
    {
        public BibliotecaDBDataContext(DbContextOptions<BibliotecaDBDataContext> options) : base(options) { }
        public DbSet<BooksModel> Books { get; set; }
        public DbSet<MembersModel> Members { get; set; }
        public DbSet<BookLoansModel> BookLoans { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
    }
}
