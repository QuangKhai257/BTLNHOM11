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
    public class khachhangController : Controller
    {
        private readonly MvcMovieContext _context;

        public khachhangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: khachhang
        public async Task<IActionResult> Index()
        {
              return _context.khachhang != null ? 
                          View(await _context.khachhang.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.khachhang'  is null.");
        }

        // GET: khachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.khachhang
                .FirstOrDefaultAsync(m => m.makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: khachhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("makh,tenkh,diachikh,sdtkh")] khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: khachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("makh,tenkh,diachikh,sdtkh")] khachhang khachhang)
        {
            if (id != khachhang.makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!khachhangExists(khachhang.makh))
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
            return View(khachhang);
        }

        // GET: khachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.khachhang
                .FirstOrDefaultAsync(m => m.makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.khachhang == null)
            {
                return Problem("Entity set 'MvcMovieContext.khachhang'  is null.");
            }
            var khachhang = await _context.khachhang.FindAsync(id);
            if (khachhang != null)
            {
                _context.khachhang.Remove(khachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool khachhangExists(string id)
        {
          return (_context.khachhang?.Any(e => e.makh == id)).GetValueOrDefault();
        }
    }
}
