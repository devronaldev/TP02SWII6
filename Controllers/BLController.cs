using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02SWII6.Models;

namespace TP02SWII6.Controllers
{
    public class BLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BL
        public IActionResult Index()
        {
            var bls = _context.BLs.ToList(); // Buscando todos os BLs
            return View(bls);
        }

        // GET: BL/Create
        public IActionResult Create()
        {
            var newBl = new BL(); // Inicializa um novo objeto BL
            return View(newBl);
        }

        // POST: BL/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        // GET: BL/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bl = await _context.BLs.FindAsync(id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }

        // POST: BL/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BL bl)
        {
            if (id != bl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BLExists(bl.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        // GET: BL/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bl = await _context.BLs.FindAsync(id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }

        // POST: BL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bl = await _context.BLs.FindAsync(id);
            if (bl != null)
            {
                _context.BLs.Remove(bl);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BLExists(int id)
        {
            return _context.BLs.Any(e => e.Id == id);
        }
    }
}
