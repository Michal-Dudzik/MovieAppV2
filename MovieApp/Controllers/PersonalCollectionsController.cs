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
    public class PersonalCollectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalCollectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalCollections
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalCollection.ToListAsync());
        }

        // GET: PersonalCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCollection = await _context.PersonalCollection
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (personalCollection == null)
            {
                return NotFound();
            }

            return View(personalCollection);
        }

        // GET: PersonalCollections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectionId,OwnerID,SelectMovieName,Score,WatchDate")] PersonalCollection personalCollection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalCollection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalCollection);
        }

        // GET: PersonalCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCollection = await _context.PersonalCollection.FindAsync(id);
            if (personalCollection == null)
            {
                return NotFound();
            }
            return View(personalCollection);
        }

        // POST: PersonalCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectionId,OwnerID,SelectMovieName,Score,WatchDate")] PersonalCollection personalCollection)
        {
            if (id != personalCollection.CollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalCollection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalCollectionExists(personalCollection.CollectionId))
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
            return View(personalCollection);
        }

        // GET: PersonalCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCollection = await _context.PersonalCollection
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (personalCollection == null)
            {
                return NotFound();
            }

            return View(personalCollection);
        }

        // POST: PersonalCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalCollection = await _context.PersonalCollection.FindAsync(id);
            _context.PersonalCollection.Remove(personalCollection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalCollectionExists(int id)
        {
            return _context.PersonalCollection.Any(e => e.CollectionId == id);
        }
    }
}
