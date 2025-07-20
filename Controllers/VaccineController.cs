using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccineManagement.Data;
using VaccineManagement.Models;
using System.Linq;

namespace VaccineManagement.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly VaccineContext _context;

        public VaccinesController(VaccineContext context)
        {
            _context = context;
        }

        // List all vaccines
        public IActionResult Index()
        {
            var items = _context.Vaccines.ToList();
            return View(items);
        }

        // GET: Create new vaccine
        public IActionResult Create() => View();

        // POST: Create new vaccine
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Vaccine vaccine)
        {
            vaccine.TotalDosesReceived = 0;
            vaccine.TotalDosesLeft     = 0;
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Add doses to existing vaccine
        public IActionResult NewDoses()
        {
            ViewBag.VaccineList = new SelectList(_context.Vaccines, "Id", "Name");
            return View();
        }

        // POST: Add doses
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult NewDoses(int Id, int NewDosesReceived)
        {
            var v = _context.Vaccines.Find(Id);
            if (v != null)
            {
                v.TotalDosesReceived += NewDosesReceived;
                v.TotalDosesLeft     += NewDosesReceived;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit vaccine
        public IActionResult Edit(int id)
        {
            var v = _context.Vaccines.Find(id);
            if (v == null) return NotFound();
            return View(v);
        }

        // POST: Edit vaccine
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Vaccine vaccine)
        {
            if (!ModelState.IsValid) return View(vaccine);

            _context.Vaccines.Update(vaccine);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
