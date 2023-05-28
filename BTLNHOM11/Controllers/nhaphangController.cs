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
    public class nhaphangController : Controller
    {
        private readonly MvcMovieContext _context;

        public nhaphangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: nhaphang
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.nhaphang.Include(n => n.nhacungcap).Include(n => n.sanpham);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: nhaphang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.nhaphang
                .Include(n => n.nhacungcap)
                .Include(n => n.sanpham)
                .FirstOrDefaultAsync(m => m.idnh == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // GET: nhaphang/Create
        public IActionResult Create()
        {
            ViewData["tenncc"] = new SelectList(_context.nhacungcap, "mancc", "mancc");
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp");
            return View();
        }

        // POST: nhaphang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idnh,tensp,tenncc,soluongnh,ngaynh")] nhaphang nhaphang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaphang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tenncc"] = new SelectList(_context.nhacungcap, "mancc", "mancc", nhaphang.tenncc);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", nhaphang.tensp);
            return View(nhaphang);
        }

        // GET: nhaphang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.nhaphang.FindAsync(id);
            if (nhaphang == null)
            {
                return NotFound();
            }
            ViewData["tenncc"] = new SelectList(_context.nhacungcap, "mancc", "mancc", nhaphang.tenncc);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", nhaphang.tensp);
            return View(nhaphang);
        }

        // POST: nhaphang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("idnh,tensp,tenncc,soluongnh,ngaynh")] nhaphang nhaphang)
        {
            if (id != nhaphang.idnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaphang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhaphangExists(nhaphang.idnh))
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
            ViewData["tenncc"] = new SelectList(_context.nhacungcap, "mancc", "mancc", nhaphang.tenncc);
            ViewData["tensp"] = new SelectList(_context.sanpham, "masp", "masp", nhaphang.tensp);
            return View(nhaphang);
        }

        // GET: nhaphang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.nhaphang
                .Include(n => n.nhacungcap)
                .Include(n => n.sanpham)
                .FirstOrDefaultAsync(m => m.idnh == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // POST: nhaphang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.nhaphang == null)
            {
                return Problem("Entity set 'MvcMovieContext.nhaphang'  is null.");
            }
            var nhaphang = await _context.nhaphang.FindAsync(id);
            if (nhaphang != null)
            {
                _context.nhaphang.Remove(nhaphang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhaphangExists(string id)
        {
          return (_context.nhaphang?.Any(e => e.idnh == id)).GetValueOrDefault();
        }
    }
}
