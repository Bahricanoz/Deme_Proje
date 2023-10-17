using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Deme_Proje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator(); // Business layderda oluşturuğumuz ProductValidatordan bir nesne türettik
            ValidationResult result = validationRules.Validate(p); //  FluentValidation.Results sınıfından ValidaionResult nesnesni türettik biz bunları valide ederek kurallarımıza ulşamış oldu
            if (result.IsValid) // result geçerlliyse
            {
                productManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else // valisdayona takıldıysa
            {
                foreach(var item in result.Errors) // result erros hata sonucları
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);// Modelin içerisine hataları ekle hangi propertyde hata var ve mesajı
                }
            }
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.GetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProdcut(int id)
        {
            var values = productManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProdcut(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                productManager.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
