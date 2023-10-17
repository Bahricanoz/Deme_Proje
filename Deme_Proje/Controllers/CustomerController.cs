using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Deme_Proje.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomerListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            JobManager jobManager = new JobManager(new EfJobDal());
            List<SelectListItem> job = (from x in jobManager.GetList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.JobId.ToString()
                                        }).ToList();
            ViewBag.job = job;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                customerManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                
            }
            return View();
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.GetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            JobManager jobManager = new JobManager(new EfJobDal());
            List<SelectListItem> job = (from x in jobManager.GetList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.JobId.ToString()
                                        }).ToList();
            ViewBag.Job = job;
            var find = customerManager.GetById(id);
            return View(find);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                customerManager.TUpdate(p);
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
