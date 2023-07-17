using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2204MDotNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using T2204MDotNetCore.Models;

namespace T2204MDotNetCore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            //ViewBag.products = _context.Products.ToList<Product>();
         
            var ctgr = _context.Categories
                //.Where(c=>c.Name.Contains("Phone"))
                .OrderBy(c => c.Name)
                .Include(c => c.Products)
                .OrderByDescending(c => c.Name)
                .ToList<Category>();
            //List<Category> categories = _context.Categories.ToList();
            //ViewData["category"]= ctgr;
            //ViewBag.categorized = ctgr;
            return View(ctgr);
        }
        public IActionResult Create() {
            var model = new CategoryModelView();
            model.products = _context.Products.ToList<Product>();
            return View(model); 
        }

        [HttpPost]
        public IActionResult Create(CategoryModelView viewmodel)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(new Category { Name = viewmodel.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Categories.Find(Id);
            if (category == null)
                return NotFound();
            return View(new EditCategoryViewModel { Id = Id, Name = category.Name });
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(new Category { Id = model.Id, Name = model.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile Image)
        {
            if (Image == null)
            {
                return BadRequest("Vui lòng up file đính kèm");
            }
            var path = "wwwroot/uploads";
            var fileName = Guid.NewGuid().ToString() + Path.GetFileName(Image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            Image.CopyTo(new FileStream(upload, FileMode.Create));
            var rs = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(rs);
        }

    }
}
