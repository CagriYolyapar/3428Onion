using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.ENTITIES.Models;
using WebCoreUI.VMClasses;

namespace WebCoreUI.Controllers
{
    public class CategoryController : Controller
    {

        readonly ICategoryManager _icm;

        public CategoryController(ICategoryManager icm)
        {

            _icm = icm;

        }
        public IActionResult CategoryList()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _icm.GetActives()
            };
            return View(cvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            TempData["message"] = _icm.Add(category);
            return RedirectToAction("CategoryList");
        }

        public IActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _icm.Find(id)
            };
            return View(cvm);


        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _icm.Update(category);
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            _icm.Delete(_icm.Find(id));
            return RedirectToAction("CategoryList");
        }
    }
}
