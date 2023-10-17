using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Deme_Proje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
        public IActionResult DeleteCategory(int id)
        {
            var find = categoryManager.GetById(id);
            categoryManager.TDelete(find);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                categoryManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var find = categoryManager.GetById(id);
            return View(find);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                categoryManager.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}
