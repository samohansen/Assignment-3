using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Models;

namespace Assignment_3.Controllers
{
    public class MovieFormModelsController : Controller
    {
        private readonly MovieFormContext _context;

        public MovieFormModelsController(MovieFormContext context)
        {
            _context = context;
        }

        // GET: MovieFormModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: MovieFormModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFormModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.Title == id);
            if (movieFormModel == null)
            {
                return NotFound();
            }

            return View(movieFormModel);
        }

        // GET: MovieFormModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieFormModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Title,Year,Director,Rating,Edited,Lentto,Notes")] MovieFormModel movieFormModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieFormModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieFormModel);
        }

        // GET: MovieFormModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFormModel = await _context.Movies.FindAsync(id);
            if (movieFormModel == null)
            {
                return NotFound();
            }
            return View(movieFormModel);
        }

        // POST: MovieFormModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Category,Title,Year,Director,Rating,Edited,Lentto,Notes")] MovieFormModel movieFormModel)
        {
            if (id != movieFormModel.Title)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieFormModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieFormModelExists(movieFormModel.Title))
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
            return View(movieFormModel);
        }

        // GET: MovieFormModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieFormModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.Title == id);
            if (movieFormModel == null)
            {
                return NotFound();
            }

            return View(movieFormModel);
        }

        // POST: MovieFormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var movieFormModel = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieFormModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieFormModelExists(string id)
        {
            return _context.Movies.Any(e => e.Title == id);
        }
    }
}
