using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/brand")]
    public class BrandController : ControllerBase
    {
        private readonly Sem3DotnetApiContext _context;

        public BrandController(Sem3DotnetApiContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var b = _context.Brands.ToList<Brand>();
            return Ok(b);
        }

        [HttpGet, Route("get-by-id")]
        public IActionResult Details(int id)
        {
            var b = _context.Brands.Find(id);
            if (b == null) return NotFound();
            return Ok(new BrandDTO { name = b.Name, id = b.Id, logo = b.Logo });
        }

        /*
        [HttpPost]
        public IActionResult Create(BrandDTO data)
        {
            if (ModelState.IsValid)
            {
                var c = new Brand { Name = data.name, Logo = data.logo };
                _context.Brands.Add(c);
                _context.SaveChanges();
                return Created($"/get-by-id?id={c.Id}", new BrandDTO { id = c.Id, name = c.Name, logo = c.Logo });
            }
            return BadRequest();
        }
        */
        [HttpPut]
        public IActionResult Update(BrandDTO data)
        {
            if (ModelState.IsValid)
            {
                var c = new Brand { Logo = data.logo, Name = data.name };
                _context.Brands.Add(c);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var b = _context.Brands.Find(id);
            if (b == null) return NotFound();
            _context.Brands.Remove(b);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
