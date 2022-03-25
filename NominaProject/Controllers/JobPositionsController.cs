using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NominaProject;
using NominaProject.Data;

namespace NominaProject.Controllers
{
    public class JobPositionsController : Controller
    {
        private readonly AppDbContext _context;

        public JobPositionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: JobPositions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.JobPosition.Include(j => j.Department);
            return View(await appDbContext.ToListAsync());
        }

        // GET: JobPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosition = await _context.JobPosition
                .Include(j => j.Department)
                .FirstOrDefaultAsync(m => m.IdPosition == id);
            if (jobPosition == null)
            {
                return NotFound();
            }

            return View(jobPosition);
        }

        // GET: JobPositions/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName");
            return View();
        }

        // POST: JobPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPosition,PositionName,DepartmentId,RiskLevel,MaxSalary,MinSalary")] JobPosition jobPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", jobPosition.DepartmentId);
            return View(jobPosition);
        }

        // GET: JobPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosition = await _context.JobPosition.FindAsync(id);
            if (jobPosition == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", jobPosition.DepartmentId);
            return View(jobPosition);
        }

        // POST: JobPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPosition,PositionName,DepartmentId,RiskLevel,MaxSalary,MinSalary")] JobPosition jobPosition)
        {
            if (id != jobPosition.IdPosition)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPositionExists(jobPosition.IdPosition))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", jobPosition.DepartmentId);
            return View(jobPosition);
        }

        // GET: JobPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosition = await _context.JobPosition
                .Include(j => j.Department)
                .FirstOrDefaultAsync(m => m.IdPosition == id);
            if (jobPosition == null)
            {
                return NotFound();
            }

            return View(jobPosition);
        }

        // POST: JobPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobPosition = await _context.JobPosition.FindAsync(id);
            _context.JobPosition.Remove(jobPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobPositionExists(int id)
        {
            return _context.JobPosition.Any(e => e.IdPosition == id);
        }
    }
}
