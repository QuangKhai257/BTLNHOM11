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
    public class nhanvienController : Controller
    {
        private readonly MvcMovieContext _context;

        public nhanvienController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: nhanvien
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.nhanvien.Include(n => n.chucvu);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien
                .Include(n => n.chucvu)
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: nhanvien/Create
        public IActionResult Create()
        {
            ViewData["tencv"] = new SelectList(_context.chucvu, "idcv", "idcv");//TENCV
            return View();
        }

        // POST: nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("manv,tennv,gtnv,nsnv,sdtnv,diachinv,emailnv,tencv,ngaylamnv")] nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tencv"] = new SelectList(_context.chucvu, "idcv", "idcv", nhanvien.tencv);
            return View(nhanvien);
        }

        // GET: nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["tencv"] = new SelectList(_context.chucvu, "idcv", "idcv", nhanvien.tencv);
            return View(nhanvien);
        }

        // POST: nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("manv,tennv,gtnv,nsnv,sdtnv,diachinv,emailnv,tencv,ngaylamnv")] nhanvien nhanvien)
        {
            if (id != nhanvien.manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhanvienExists(nhanvien.manv))
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
            ViewData["tencv"] = new SelectList(_context.chucvu, "idcv", "idcv", nhanvien.tencv);
            return View(nhanvien);
        }

        // GET: nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.nhanvien
                .Include(n => n.chucvu)
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.nhanvien == null)
            {
                return Problem("Entity set 'MvcMovieContext.nhanvien'  is null.");
            }
            var nhanvien = await _context.nhanvien.FindAsync(id);
            if (nhanvien != null)
            {
                _context.nhanvien.Remove(nhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhanvienExists(string id)
        {
          return (_context.nhanvien?.Any(e => e.manv == id)).GetValueOrDefault();
        }
    }
}
