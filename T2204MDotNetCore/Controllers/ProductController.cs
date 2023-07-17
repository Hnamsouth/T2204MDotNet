using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using T2204MDotNetCore.Entities;
using T2204MDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace T2204MDotNetCore.Controllers
{
    public class ProductController : Controller
    {

        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            var product = _context.Products.ToList<Product>();
            return View(product);
        }
        public IActionResult Create()
        {
            var ctgr = _context.Categories.OrderBy(c => c.Name).OrderByDescending(c => c.Name).ToList<Category>();
            var brands = _context.Brands.OrderBy(c => c.Name).OrderByDescending(c => c.Name).ToList<Brand>();

            var model = new ProductModelView();
            model.categories = new List<SelectListItem>();
            model.brands = new List<SelectListItem>();
            model.categories.Add(new SelectListItem { Text = "Laptop", Value = "1" });
            model.brands.Add(new SelectListItem { Text = "Apple", Value = "1" });

            ViewBag.Model = model;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductModelView modelview) {
            if(ModelState.IsValid)
            {
                _context.Products.Add(new Product {
                    Name = modelview.Name,
                    Price = modelview.Price,
                    Description= modelview.Description,
                    CategorId = modelview.CategorId,
                    BrandId= modelview.BrandId
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelview);
        }
    }
}
