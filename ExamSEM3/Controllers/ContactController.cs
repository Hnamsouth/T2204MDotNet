using ExamSEM3.Entities;
using ExamSEM3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamSEM3.Controllers
{
    public class ContactController : Controller
    {

        public static string check="1";
        private readonly Context _context;

        public ContactController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        async public Task<IActionResult> Index()
        {
            var model = await _context.Contacts.ToListAsync();
            return View(model);
        }

        [HttpGet]
        async public Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Create(ContactViewModel data)
        {

            
            if (ModelState.IsValid)
            {
                var check =  _context.Contacts.Any(c => c.ContactName.Equals(data.ContactName));
                if ( check)
                {
                    ModelState.AddModelError("ContactName", "Tên liên hệ đã tồn tại.");
                    return View(data);
                }
                var contact = new Contacts {ContactName=data.ContactName,ContactNumber=data.ContactNumber,GroupName=data.GroupName,HireDate=data.HireDate,Birthday=data.Birthday };
                _context.Contacts.Add(contact);
                 await  _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        async public Task<IActionResult> SortByName(string param1)
        {
            check = check=="1"?"2":"1" ;
            var model = new List<Contacts>();
            if (check == "1")
            {
                model = _context.Contacts.OrderByDescending(c => c.ContactName).ToList<Contacts>(); ;
            }
            else
            {
                model = _context.Contacts.OrderBy(c => c.ContactName).ToList<Contacts>(); ;
            }
            return View("Index", model);
        }

        [HttpPost]
        async public Task<IActionResult> Search(string searchTerm)
        {
            var model =await _context.Contacts.Where(c => c.ContactName.Contains(searchTerm)).ToListAsync();
            return View("Index", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
