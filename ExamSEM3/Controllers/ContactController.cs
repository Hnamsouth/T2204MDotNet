using ExamSEM3.Entities;
using ExamSEM3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamSEM3.Controllers
{
    public class ContactController : Controller
    {

        private readonly Context _context;

        public ContactController(Context context)
        {
            _context = context;
        }

        async public Task<IActionResult> Index()
        {
            var model = _context.Contacts.ToList<Contacts>();
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
            if(ModelState.IsValid)
            {
                var contact = new Contacts {ContactName=data.ContactName,ContactNumber=data.ContactNumber,GroupName=data.GroupName,HireDate=data.HireDate,Birthday=data.Birthday };
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        async public Task<IActionResult> SortByName()
        {
            var model = _context.Contacts.OrderByDescending(c => c.ContactName).ToList<Contacts>();
            return RedirectToAction("Index", model);
        }

        async public Task<IActionResult> Search(string data)
        {
            var model = _context.Contacts.FirstOrDefaultAsync(m=> m.ContactName==data);
            return RedirectToAction("Index", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
