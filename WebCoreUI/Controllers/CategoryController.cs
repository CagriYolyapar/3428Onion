using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.ENTITIES.Models;

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
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            return RedirectToAction("CategoryList");
        }
    }
}
