using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaProject.Data;
using NominaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Controllers
{
    public class DeductionsController : Controller
    {
        private readonly AppDbContext _context;

        public DeductionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deduction.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction
                .FirstOrDefaultAsync(m => m.IdDeduction == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDeduction,DeductionName,Apply,State")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deduction);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction.FindAsync(id);
            if (deduction == null)
            {
                return NotFound();
            }
            return View(deduction);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDeduction,DeductionName,Apply,State")] Deduction deduction)
        {
            if (id != deduction.IdDeduction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionsExists(deduction.IdDeduction))
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
            return View(deduction);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deduction
                .FirstOrDefaultAsync(m => m.IdDeduction == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deduction = await _context.Deduction.FindAsync(id);
            _context.Deduction.Remove(deduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionsExists(int id)
        {
            return _context.Deduction.Any(e => e.IdDeduction == id);
        }
    }
}
