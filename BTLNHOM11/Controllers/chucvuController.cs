using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM11.Models;
using MvcMovie.Data;

namespace BTLNHOM11.Controllers
{
    public class chucvuController : Controller
    {
        private readonly MvcMovieContext _context;

        public chucvuController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: chucvu
        public async Task<IActionResult> Index()
        {
              return _context.chucvu != null ? 
                          View(await _context.chucvu.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.chucvu'  is null.");
        }

        // GET: chucvu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.chucvu == null)
            {
                return NotFound();
            }

            var chucvu = await _context.chucvu
                .FirstOrDefaultAsync(m => m.idcv == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // GET: chucvu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: chucvu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idcv,tencv,motacv")] chucvu chucvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucvu);
        }

        // GET: chucvu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.chucvu == null)
            {
                return NotFound();
            }

            var chucvu = await _context.chucvu.FindAsync(id);
            if (chucvu == null)
            {
                return NotFound();
            }
            return View(chucvu);
        }

        // POST: chucvu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idcv,tencv,motacv")] chucvu chucvu)
        {
            if (id != chucvu.idcv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chucvuExists(chucvu.idcv))
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
            return View(chucvu);
        }

        // GET: chucvu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.chucvu == null)
            {
                return NotFound();
            }

            var chucvu = await _context.chucvu
                .FirstOrDefaultAsync(m => m.idcv == id);
            if (chucvu == null)
            {
                return NotFound();
            }

            return View(chucvu);
        }

        // POST: chucvu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.chucvu == null)
            {
                return Problem("Entity set 'MvcMovieContext.chucvu'  is null.");
            }
            var chucvu = await _context.chucvu.FindAsync(id);
            if (chucvu != null)
            {
                _context.chucvu.Remove(chucvu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool chucvuExists(string id)
        {
          return (_context.chucvu?.Any(e => e.idcv == id)).GetValueOrDefault();
        }
    }
}
