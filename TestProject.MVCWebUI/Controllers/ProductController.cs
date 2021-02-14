using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Business.Abstract;
using TestProject.Entity.Concrete;
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

        public JsonResult Edit(int id)
        {
            if (id > 0)
            {
                var result = _productService.GetById(id);
                return Json(result);
            }
            return Json(0);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productIsValid = _productService.GetById(productViewModel.Product.Id);
                if(productIsValid == null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForUpdate = new Product
                {
                    Id = productIsValid.Id,
                    AddedDate = productIsValid.AddedDate,
                    AddedBy = productIsValid.AddedBy,
                    CategoryId = productViewModel.Product.CategoryId,
                    Explanation = productViewModel.Product.Explanation,
                    Name = productViewModel.Product.Name,
                    Height = productViewModel.Product.Height,
                    Width = productViewModel.Product.Width,
                    Weight = productViewModel.Product.Weight
                };
                try
                {
                    _productService.Update(productForUpdate);
                    return RedirectToAction("GetProducts");
                }
                catch (Exception)
                {
                    return RedirectToAction("GetProducts");
                }
               
            }
            return RedirectToAction("GetProducts");
        }

        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productIsValid = _productService.GetByName(productViewModel.Product.Name);
                if(productIsValid == null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForAdd = new Product
                {
                    AddedDate = DateTime.Now,
                    AddedBy = "Canan Gök",
                    CategoryId = 1,
                    Explanation = productViewModel.Product.Explanation,
                    Name = productViewModel.Product.Name,
                    Height = productViewModel.Product.Height,
                    Width = productViewModel.Product.Width,
                    Weight = productViewModel.Product.Weight
                };
                try
                {
                    _productService.Add(productForAdd);
                    return RedirectToAction("GetProducts");
                }
                catch (Exception)
                {
                    return RedirectToAction("GetProducts");
                }
            }
            
            return RedirectToAction("GetProducts");
        }
    }
}