using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using United_Youth_Orchestra_with_MVC.Data;
using United_Youth_Orchestra_with_MVC.Models;

namespace United_Youth_Orchestra_with_MVC.Controllers
{
    public class SchoolyearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolyearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schoolyears
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schoolyear.ToListAsync());
        }

        // GET: Schoolyears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolyear = await _context.Schoolyear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolyear == null)
            {
                return NotFound();
            }

            return View(schoolyear);
        }

        // GET: Schoolyears/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schoolyears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Year6orEarlier,Year7,Year8,Year9,Year10,Year11,Year12,Year13,Other")] Schoolyear schoolyear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolyear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolyear);
        }

        // GET: Schoolyears/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolyear = await _context.Schoolyear.FindAsync(id);
            if (schoolyear == null)
            {
                return NotFound();
            }
            return View(schoolyear);
        }

        // POST: Schoolyears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year6orEarlier,Year7,Year8,Year9,Year10,Year11,Year12,Year13,Other")] Schoolyear schoolyear)
        {
            if (id != schoolyear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolyear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolyearExists(schoolyear.Id))
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
            return View(schoolyear);
        }

        // GET: Schoolyears/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolyear = await _context.Schoolyear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolyear == null)
            {
                return NotFound();
            }

            return View(schoolyear);
        }

        // POST: Schoolyears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolyear = await _context.Schoolyear.FindAsync(id);
            _context.Schoolyear.Remove(schoolyear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolyearExists(int id)
        {
            return _context.Schoolyear.Any(e => e.Id == id);
        }
    }
}
