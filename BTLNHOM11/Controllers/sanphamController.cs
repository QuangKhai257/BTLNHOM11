using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM11.Models;
using MvcMovie.Data;
using BTLNHOM11.Models.Process;

namespace BTLNHOM11.Controllers
{
    public class sanphamController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();
        private ExcelProcess _excelProcess = new ExcelProcess();

        public sanphamController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: sanpham
        // public async Task<IActionResult> Index()
        // {
        //       return _context.sanpham != null ? 
        //                   View(await _context.sanpham.ToListAsync()) :
        //                   Problem("Entity set 'MvcMovieContext.sanpham'  is null.");
        // }
         public async Task<IActionResult> Index(string searchString)
        {
            var sanpham = from m in _context.sanpham
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                sanpham = sanpham.Where(s => s.tensp!.Contains(searchString));
                }
            return View(await sanpham.ToListAsync());
        }

        // GET: sanpham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham
                .FirstOrDefaultAsync(m => m.masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: sanpham/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
        public IActionResult Create()
        {
            var IDdautien = "SP01";
            var countAnh = _context.sanpham.Count();
            if (countAnh > 0)
            {
                var masp = _context.sanpham.OrderByDescending(m => m.masp).First().masp;
                IDdautien = strPro.AutoGenerateCode(masp);
            }
            ViewBag.newID = IDdautien;
            return View();
        }


        // POST: sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("masp,tensp,gia")] sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanpham);
        }

        // GET: sanpham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("masp,tensp,gia")] sanpham sanpham)
        {
            if (id != sanpham.masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanphamExists(sanpham.masp))
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
            return View(sanpham);
        }

        // GET: sanpham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham
                .FirstOrDefaultAsync(m => m.masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.sanpham == null)
            {
                return Problem("Entity set 'MvcMovieContext.sanpham'  is null.");
            }
            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham != null)
            {
                _context.sanpham.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sanphamExists(string id)
        {
          return (_context.sanpham?.Any(e => e.masp == id)).GetValueOrDefault();
        }
                public async Task<IActionResult> Upload()
        {
            return View();
        }
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var sp = new sanpham();

                            sp.masp = dt.Rows[i][0].ToString();
                            sp.tensp = dt.Rows[i][1].ToString();
                            sp.gia = dt.Rows[i][2].ToString();
                           
                         _context.sanpham.Add(sp);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
    }
    }
}
