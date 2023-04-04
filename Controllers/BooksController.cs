using Microsoft.AspNetCore.Mvc;
using Biblioteca_MVC.Models;
using Biblioteca_MVC.Repositories;
using Biblioteca_MVC.ViewModels;

namespace Biblioteca_MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksRepository _repository;
        public BooksController(BooksRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetBooks();
            return View("Index",books);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create (IFormCollection collection)
        {
            BooksModel book = new BooksModel();
            TryUpdateModelAsync(book);
            _repository.Add(book);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            BooksModel book = _repository.GetBooksById(Id);
            return View("Edit",book);
        }
        [HttpPost]
        public IActionResult Edit (Guid id,IFormCollection collection)
        {
            BooksModel book = new();
            TryUpdateModelAsync(book);
            _repository.Update(book);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            BooksModel book =_repository.GetBooksById(id);
            return View("Delete", book);
        }
        [HttpPost]
        public IActionResult Delete (Guid id,IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details (Guid Id)
        {
            BooksModel book = _repository.GetBooksById(Id);
            return View("Details", book);
        }
        public ActionResult DetailsWithBooksBookLoans(Guid id)
        {
            BooksBookLoansViewModel viewModel = _repository.GetBooksBookLoans(id);
            return View("DetailsWithBooksBookLoans", viewModel);
        }
    }
}
