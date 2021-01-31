using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Business.Abstract;
using TestProject.MVCWebUI.Models;

namespace TestProject.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult GetProducts()
        {
            var productViewModel = new ProductViewModel
            {
                Products = _productService.GetList()
            };
            return View(productViewModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}