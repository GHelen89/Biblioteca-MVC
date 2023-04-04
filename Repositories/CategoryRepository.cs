using Biblioteca_MVC.DataContext;
using Biblioteca_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_MVC.Repositories
{
    public class CategoryRepository
    { 
           private readonly BibliotecaDBDataContext _context;
           public CategoryRepository(BibliotecaDBDataContext context)
           {
                _context = context;
           }
           public DbSet<CategoryModel> GetCategory()
           {
                return _context.Category;
           }
           public void Add(CategoryModel model)
           {
                model.IDCategorie = Guid.NewGuid();
                _context.Category.Add(model);
                _context.SaveChanges();
           }
           public CategoryModel GetCategoryById(Guid Id)
           {
              CategoryModel category = _context.Category.FirstOrDefault(x => x.IDCategorie == Id);

              return category;
           }
            public void Update(CategoryModel model)
            {
               _context.Category.Update(model);
               _context.SaveChanges();
            } 
            public void Delete(Guid id)
            {
               CategoryModel book = GetCategoryById(id);
               _context.Category.Remove(book);
               _context.SaveChanges();
            }
        
    }
}
