
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly Sem3DotnetApiContext _context;

        public ProductController(Sem3DotnetApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = _context.Products.Include(p => p.Category).Include(p => p.Brand).ToArray();
            if(product == null) { return NotFound(); }
            return Ok(product);
        }

        [HttpGet,Route("get-by-id")]
        public IActionResult Index(int id)
        {
            var p = _context.Products.Find(id);
            if(p==null) return NotFound();
            return Ok(new ProductDTO { id=p.Id,name=p.Name,thumnail = p.Thumnail, price = p.Price, qty = p.Qty, description =p.Description });
        }

        [HttpPost]
        public IActionResult Create(ProductDTO d)
        {
            if (ModelState.IsValid)
            {
                var p = new Product { Name = d.name, Thumnail = d.thumnail, Price = d.price, Qty = d.qty, Description = d.description, CategoryId = d.categoryId, BrandId = d.brandId };
                _context.Products.Add(p);
                _context.SaveChanges();
                return Created($"get-by-id?id={p.Id}", new ProductDTO { id = p.Id, name = p.Name, thumnail = p.Thumnail, price = p.Price, qty = p.Qty, description = p.Description });
            }
              return BadRequest(d);
        }

        [HttpPut]
        public IActionResult Update(ProductDTO d) {
            if (ModelState.IsValid)
            {
                var p = new Product { Id=d.id, Name = d.name, Thumnail = d.thumnail, Price = d.price, Qty = d.qty, Description = d.description, CategoryId = d.categoryId, BrandId = d.brandId };
                _context.Products.Update(p);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
          
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var p = _context.Products.Find(id);
            if (p == null) return NotFound();
            _context.Products.Remove(p);
            _context.SaveChanges();
            return NoContent();
        }

      
    }
}
