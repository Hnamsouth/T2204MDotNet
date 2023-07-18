using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using T2204MDotNetCore.Entities;
using T2204MDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace T2204MDotNetCore.Controllers
{
    public class ProductController : Controller
    {

        private readonly Context _context;
        public ProductController(Context context)
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
            var ctgr = _context.Categories.ToList<Category>();
            var brands = _context.Brands.ToList<Brand>();

          
            var model = new ProductModelView();
            model.categories = ctgr;
            model.brands = brands;
        
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

            return RedirectToAction("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
