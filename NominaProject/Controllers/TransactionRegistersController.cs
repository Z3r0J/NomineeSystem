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
    public class TransactionRegistersController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionRegistersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TransactionRegisters
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TransactionRegister.Include(e=>e.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TransactionRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionRegister = await _context.TransactionRegister.Include(e=>e.TypeTransaction).Include(e=>e.Employee)
                .FirstOrDefaultAsync(m => m.IdTransaction == id);
            if (transactionRegister == null)
            {
                return NotFound();
            }

            return View(transactionRegister);
        }

        // GET: TransactionRegisters/Create
        public IActionResult Create()
        {
            ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName");
            var Lista = _context.Employees.Select(x => new { Id = x.IdEmployee,Name=$"{x.FirstName} {x.LastName}"
        }).ToList();
            ViewData["Employee"] = new SelectList(Lista, "Id", "Name");


            return View();
        }

        // POST: TransactionRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaction,EmployeeIdEmployee,IdDeductionOrIncome,TypeTransactionIdTypeTransaction,Date,Amount,State")] TransactionRegister transactionRegister)
        {
            if (ModelState.IsValid)
            {
                if (transactionRegister.TypeTransactionIdTypeTransaction == 1)
                {
                    if (transactionRegister.Amount >= _context.Employees.Where(x => x.IdEmployee == transactionRegister.EmployeeIdEmployee).Select(x => x.MonthlySalary).First())
                    {
                        ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName", transactionRegister.TypeTransactionIdTypeTransaction);
                        var list = _context.Employees.Select(x => new {
                            Id = x.IdEmployee,
                            Name = $"{x.FirstName} {x.LastName}"
                        }).ToList();
                        ViewData["Employee"] = new SelectList(list, "Id", "Name", transactionRegister.EmployeeIdEmployee);
                        ViewBag.ErrorMessage = $"The amount of deduction must be between {_context.Employees.Where(x => x.IdEmployee == transactionRegister.EmployeeIdEmployee).Select(x => x.MonthlySalary).First()}";
                        return View();
                    }
                }
                _context.Add(transactionRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName",transactionRegister.TypeTransactionIdTypeTransaction);
            var Lista = _context.Employees.Select(x => new {
                Id = x.IdEmployee,
                Name = $"{x.FirstName} {x.LastName}"
            }).ToList();
            ViewData["Employee"] = new SelectList(Lista, "Id", "Name",transactionRegister.EmployeeIdEmployee);


            return View(transactionRegister);
        }

        // GET: TransactionRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionRegister = await _context.TransactionRegister.FindAsync(id);
            if (transactionRegister == null)
            {
                return NotFound();
            }
            ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName");
            var Lista = _context.Employees.Select(x => new {
                Id = x.IdEmployee,
                Name = $"{x.FirstName} {x.LastName}"
            }).ToList();
            ViewData["Employee"] = new SelectList(Lista, "Id", "Name");

            return View(transactionRegister);
        }

        // POST: TransactionRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaction,EmployeeIdEmployee,IdDeductionOrIncome,TypeTransactionIdTypeTransaction,Date,Amount,State")] TransactionRegister transactionRegister)
        {
            if (id != transactionRegister.IdTransaction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (transactionRegister.TypeTransactionIdTypeTransaction == 1)
                    {
                        if (transactionRegister.Amount >= _context.Employees.Where(x => x.IdEmployee == transactionRegister.EmployeeIdEmployee).Select(x => x.MonthlySalary).First())
                        {
                            ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName");
                            var list = _context.Employees.Select(x => new {
                                Id = x.IdEmployee,
                                Name = $"{x.FirstName} {x.LastName}"
                            }).ToList();
                            ViewData["Employee"] = new SelectList(list, "Id", "Name");
                            ViewBag.ErrorMessage = $"The amount of deduction must be between {_context.Employees.Where(x => x.IdEmployee == transactionRegister.EmployeeIdEmployee).Select(x => x.MonthlySalary).First()}";
                            return View();
                        }
                    }
                    _context.Update(transactionRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionRegisterExists(transactionRegister.IdTransaction))
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
            ViewData["TypeTransaction"] = new SelectList(_context.TypeTransaction, "IdTypeTransaction", "TypeName",transactionRegister.TypeTransactionIdTypeTransaction);
            var Lista = _context.Employees.Select(x => new {
                Id = x.IdEmployee,
                Name = $"{x.FirstName} {x.LastName}"
            }).ToList();
            ViewData["Employee"] = new SelectList(Lista, "Id", "Name", transactionRegister.EmployeeIdEmployee);
            return View(transactionRegister);
        }
        public JsonResult loadTypeTransaction(int IdTypeTransaction)
        {
            if (IdTypeTransaction == 1)
            {
                var Deduction = _context.Deduction.Select(s => new
                {
                    Id = s.IdDeduction,
                    Name = s.DeductionName
                }).ToList();
                return Json(Deduction);
            }
            else if (IdTypeTransaction == 2)
            {
                var Income = _context.Income.Select(s => new
                {
                    Id = s.incomeId,
                    Name = s.incomeName
                }).ToList();
                return Json(Income);
            }
            else
            {
                return Json("");
            }
        }

        // GET: TransactionRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionRegister = await _context.TransactionRegister
                .FirstOrDefaultAsync(m => m.IdTransaction == id);
            if (transactionRegister == null)
            {
                return NotFound();
            }

            return View(transactionRegister);
        }

        // POST: TransactionRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionRegister = await _context.TransactionRegister.FindAsync(id);
            _context.TransactionRegister.Remove(transactionRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionRegisterExists(int id)
        {
            return _context.TransactionRegister.Any(e => e.IdTransaction == id);
        }
    }
}
