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
    public class hoadonController : Controller
    {
        private readonly MvcMovieContext _context;

        public hoadonController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: hoadon
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.hoadon.Include(h => h.khachhang).Include(h => h.sanpham);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: hoadon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon
                .Include(h => h.khachhang)
                .Include(h => h.sanpham)
                .FirstOrDefaultAsync(m => m.mahd == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: hoadon/Create
        public IActionResult Create()
        {
            ViewData["tenkh"] = new SelectList(_context.khachhang, "makh", "makh");
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp");
            return View();
        }

        // POST: hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mahd,tenkh,tensp,soluongban,tgban")] hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tenkh"] = new SelectList(_context.khachhang, "makh", "makh", hoadon.tenkh);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", hoadon.tensp);
            return View(hoadon);
        }

        // GET: hoadon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["tenkh"] = new SelectList(_context.khachhang, "makh", "makh", hoadon.tenkh);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", hoadon.tensp);
            return View(hoadon);
        }

        // POST: hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("mahd,tenkh,tensp,soluongban,tgban")] hoadon hoadon)
        {
            if (id != hoadon.mahd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hoadonExists(hoadon.mahd))
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
            ViewData["tenkh"] = new SelectList(_context.khachhang, "makh", "makh", hoadon.tenkh);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", hoadon.tensp);
            return View(hoadon);
        }

        // GET: hoadon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon
                .Include(h => h.khachhang)
                .Include(h => h.sanpham)
                .FirstOrDefaultAsync(m => m.mahd == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.hoadon == null)
            {
                return Problem("Entity set 'MvcMovieContext.hoadon'  is null.");
            }
            var hoadon = await _context.hoadon.FindAsync(id);
            if (hoadon != null)
            {
                _context.hoadon.Remove(hoadon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hoadonExists(string id)
        {
          return (_context.hoadon?.Any(e => e.mahd == id)).GetValueOrDefault();
        }
    }
}
