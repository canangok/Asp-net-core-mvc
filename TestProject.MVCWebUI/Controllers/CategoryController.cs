using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Business.Abstract;
using TestProject.MVCWebUI.Models;

namespace TestProject.MVCWebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult GetCategories()
        {
            var categoryViewModel = new CategoryViewModel
            {
                Categories = _categoryService.GetList()
            };
            return View(categoryViewModel);
        }
    }
}