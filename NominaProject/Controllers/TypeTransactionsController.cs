using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NominaProject.Data;
using NominaProject.Models;

namespace NominaProject.Controllers
{
    public class TypeTransactionsController : Controller
    {
        private readonly AppDbContext _context;

        public TypeTransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TypeTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeTransaction.ToListAsync());
        }

        // GET: TypeTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTransaction = await _context.TypeTransaction
                .FirstOrDefaultAsync(m => m.IdTypeTransaction == id);
            if (typeTransaction == null)
            {
                return NotFound();
            }

            return View(typeTransaction);
        }

        // GET: TypeTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeTransaction,TypeName")] TypeTransaction typeTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeTransaction);
        }

        // GET: TypeTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTransaction = await _context.TypeTransaction.FindAsync(id);
            if (typeTransaction == null)
            {
                return NotFound();
            }
            return View(typeTransaction);
        }

        // POST: TypeTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypeTransaction,TypeName")] TypeTransaction typeTransaction)
        {
            if (id != typeTransaction.IdTypeTransaction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeTransactionExists(typeTransaction.IdTypeTransaction))
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
            return View(typeTransaction);
        }

        // GET: TypeTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTransaction = await _context.TypeTransaction
                .FirstOrDefaultAsync(m => m.IdTypeTransaction == id);
            if (typeTransaction == null)
            {
                return NotFound();
            }

            return View(typeTransaction);
        }

        // POST: TypeTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeTransaction = await _context.TypeTransaction.FindAsync(id);
            _context.TypeTransaction.Remove(typeTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeTransactionExists(int id)
        {
            return _context.TypeTransaction.Any(e => e.IdTypeTransaction == id);
        }
    }
}
