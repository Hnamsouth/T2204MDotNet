using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs; // data transfer objects
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    //default url like: api/Category/Create chi dinh phuong thuc de xu ly
    // [Route("api/[controller]/{action}")] 
    [Route("api/categories")]
    // dua vao phuong thuc de xu ly
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Sem3DotnetApiContext _context;

        public CategoryController(Sem3DotnetApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var c = _context.Categories.Include(c=>c.Products).ToArray();

            
            List<CategoryDTO> cs= new List<CategoryDTO>();
            foreach (var i in c)
            {
                List<ProductDTO> plist = new List<ProductDTO>();

                foreach (var p in i.Products)
                {
                    plist.Add(new ProductDTO { id = p.Id, name = p.Name });
                }

                cs.Add(new CategoryDTO { id = i.Id, name = i.Name,products = plist });
            }

            return Ok(c);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById(int id)
        {
            var c = _context.Categories.Find(id);
            if(c==null) return NotFound();
            return Ok(new CategoryDTO { id = c.Id,name = c.Name});
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO data) {
            if (ModelState.IsValid)
            {
                var c = new Category { Name = data.name };
               _context.Categories.Add(c);
                _context.SaveChanges();
                return Created($"/get-by-id?id={c.Id}", new CategoryDTO { id=c.Id,name=c.Name});
            }
            return BadRequest();

        }

        [HttpPut]
        public IActionResult Update(CategoryDTO data)
        {
            if (ModelState.IsValid)
            {
                var c = new Category { Id = data.id, Name = data.name };
                _context.Categories.Update(c);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        
        }

        [HttpDelete] public IActionResult Delete(int id)
        {
            var c = _context.Categories.Find(id);
            if(c==null) return NotFound();
            _context.Categories.Remove(c);
            _context.SaveChanges();
            return NoContent(); 
        }

      

    }
}
