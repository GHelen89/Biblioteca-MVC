using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Biblioteca_MVC.Repositories;
using Biblioteca_MVC.Models;

namespace Biblioteca_MVC.Controllers
{
    public class CategoryController : Controller
    {
        
            private readonly CategoryRepository _repository;
            public CategoryController(CategoryRepository repository)
            {
                _repository = repository;
            }
            public IActionResult Index()
            {
                var category = _repository.GetCategory();
                return View("Index", category);
            }
            public IActionResult Create()
            {
                return View("Create");
            }

            [HttpPost]
            public IActionResult Create(IFormCollection collection)
            {
                CategoryModel category = new CategoryModel();
                TryUpdateModelAsync(category);// se mmappeaza datele din formular pee modelul annoucement
                _repository.Add(category);
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult Edit(Guid id)
            {
                CategoryModel category = _repository.GetCategoryById(id);
                return View("Edit",category);
            }
            [HttpPost]
            public IActionResult Edit(Guid id, IFormCollection collecttion)
            {
                CategoryModel category = new();
                TryUpdateModelAsync(category);
                _repository.Update(category);
                return RedirectToAction("Index");

            }
            [HttpGet]
            public IActionResult Delete(Guid id)
            {
                CategoryModel category = _repository.GetCategoryById(id);
                return View("Delete", category);
            }
            [HttpPost]
            public IActionResult Delete(Guid id, IFormCollection collection)
            {
                _repository.Delete(id);
                return RedirectToAction("Index");
            }
            public IActionResult Details(Guid id)
            {
                CategoryModel category = _repository.GetCategoryById(id);
                return View("Details", category);
            }

    }
}