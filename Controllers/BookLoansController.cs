using Biblioteca_MVC.Models;
using Biblioteca_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_MVC.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly BookLoansRepository _repository;
        private readonly MembersRepository _membersRepository;
        private readonly BooksRepository _booksRepository;
        public BookLoansController(BookLoansRepository repository,MembersRepository membersRepository, BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
            _membersRepository = membersRepository;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var books = _repository.GetBookLoans();
            return View("Index", books);
        }
        public IActionResult Create()
        {
            var members = _membersRepository.GetMembers();
            ViewBag.data=members;
            var books = _booksRepository.GetBooks();
            ViewBag.data2=books;
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            BookLoansModel bookloans = new BookLoansModel();
            TryUpdateModelAsync(bookloans);
            _repository.Add(bookloans);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            BookLoansModel bookloans = _repository.GetBookLoansById(Id);
            return View("Edit", bookloans);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            BookLoansModel bookloans = new();
            TryUpdateModelAsync(bookloans);
            _repository.Update(bookloans);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            BookLoansModel bookloans = _repository.GetBookLoansById(id);
            return View("Delete", bookloans);
        }
        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid Id)
        {
            BookLoansModel book = _repository.GetBookLoansById(Id);
            return View("Details", book);
        }

    }
}
