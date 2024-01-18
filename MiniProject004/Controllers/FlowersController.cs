using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MiniProject004.Models;

namespace MiniProject004.Controllers
{
    public class FlowersController : Controller
    {
        private readonly Context _context;

        public FlowersController(Context context)
        {
            _context = context;
        }

        // GET: Flowers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flowers.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(string? searchWord)
        {
            searchWord = (searchWord == string.Empty || searchWord is null) ? "" : searchWord;
            ViewBag.SearchWord = searchWord;
            var result = _context.Flowers.Where(f => f.ENGName.Contains(searchWord)).ToList();
            return View(result);
        }

        // GET: Flowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flowers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // GET: Flowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ENGName,GERName,POLName")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        // GET: Flowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flowers.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ENGName,GERName,POLName")] Flower flower)
        {
            if (id != flower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.Id))
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
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flowers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower != null)
            {
                _context.Flowers.Remove(flower);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerExists(int id)
        {
            return _context.Flowers.Any(e => e.Id == id);
        }
    }
}
