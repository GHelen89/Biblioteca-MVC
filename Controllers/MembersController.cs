using Biblioteca_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Biblioteca_MVC.Models;
using Biblioteca_MVC.ViewModels;

namespace Biblioteca_MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _repository;
        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index",members);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MembersModel member = new MembersModel();
            TryUpdateModelAsync(member);
            _repository.Add(member);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit (Guid Id)
        {
            MembersModel member = _repository.GetMemberById(Id);
            return View("Edit",member);
        }
        [HttpPost]
        public IActionResult Edit (Guid id,IFormCollection collection)
        {
            MembersModel member = new();
            TryUpdateModelAsync(member);
            _repository.Update(member);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MembersModel member = _repository.GetMemberById(id);
            return View("Delete",member);
        }
        [HttpPost]
        public IActionResult Delete(Guid id ,IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details (Guid id)
        {
            MembersModel member = _repository.GetMemberById(id);
            return View ("Details",member);
        }
        public ActionResult DetailsWithBookLoans(Guid id)
        {
            MemberBookLoansViewModel viewModel = _repository.GetMemberBookLoans(id);
            return View("DetailsWithBookLoans", viewModel);
        }
    }
}
