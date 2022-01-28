using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieData.ToListAsync());
        }

        // GET: MovieDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieData == null)
            {
                return NotFound();
            }

            return View(movieData);
        }

        // GET: MovieDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,MovieDirector,ReleaseDate,Genre,Description,ImageName")] MovieData movieData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieData);
        }

        // GET: MovieDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData.FindAsync(id);
            if (movieData == null)
            {
                return NotFound();
            }
            return View(movieData);
        }

        // POST: MovieDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,MovieDirector,ReleaseDate,Genre,Description,ImageName")] MovieData movieData)
        {
            if (id != movieData.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDataExists(movieData.MovieId))
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
            return View(movieData);
        }

        // GET: MovieDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieData = await _context.MovieData
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieData == null)
            {
                return NotFound();
            }

            return View(movieData);
        }

        // POST: MovieDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieData = await _context.MovieData.FindAsync(id);
            _context.MovieData.Remove(movieData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDataExists(int id)
        {
            return _context.MovieData.Any(e => e.MovieId == id);
        }
    }
}
