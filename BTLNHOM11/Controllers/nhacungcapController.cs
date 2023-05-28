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
    public class nhacungcapController : Controller
    {
        private readonly MvcMovieContext _context;

        public nhacungcapController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: nhacungcap
        public async Task<IActionResult> Index()
        {
              return _context.nhacungcap != null ? 
                          View(await _context.nhacungcap.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.nhacungcap'  is null.");
        }

        // GET: nhacungcap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.nhacungcap
                .FirstOrDefaultAsync(m => m.mancc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: nhacungcap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nhacungcap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mancc,tenncc,diachincc,sdtncc,emailncc")] nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhacungcap);
        }

        // GET: nhacungcap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: nhacungcap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("mancc,tenncc,diachincc,sdtncc,emailncc")] nhacungcap nhacungcap)
        {
            if (id != nhacungcap.mancc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhacungcapExists(nhacungcap.mancc))
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
            return View(nhacungcap);
        }

        // GET: nhacungcap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.nhacungcap
                .FirstOrDefaultAsync(m => m.mancc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: nhacungcap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.nhacungcap == null)
            {
                return Problem("Entity set 'MvcMovieContext.nhacungcap'  is null.");
            }
            var nhacungcap = await _context.nhacungcap.FindAsync(id);
            if (nhacungcap != null)
            {
                _context.nhacungcap.Remove(nhacungcap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhacungcapExists(string id)
        {
          return (_context.nhacungcap?.Any(e => e.mancc == id)).GetValueOrDefault();
        }
    }
}
