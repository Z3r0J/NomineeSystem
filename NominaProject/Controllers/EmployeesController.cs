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
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Users).Include(e=>e.JobPosition);
            return Employee.IsLogged ? View(await appDbContext.ToListAsync()): RedirectToAction("Index","Home");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Users)
                .Include(e => e.JobPosition)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public JsonResult loadPosition(int DepartmentId) {

            var Position = _context.JobPosition.Where(x => x.DepartmentId == DepartmentId).Select(s => new {
                Id = s.IdPosition,
                Name = s.PositionName
            }).ToList();

            return Json(Position);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName");
            ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmployee,Documents,FirstName,LastName,DepartmentId,JobPosition,MonthlySalary,UsersIdUsers,JobPositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.MonthlySalary > _context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MaxSalary).First() || employee.MonthlySalary < _context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MinSalary).First())
                {
                    ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", employee.DepartmentId);
                    ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName", employee.UsersIdUsers);
                    ViewBag.ErrorMessage = $"The monthly salary must be between {_context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MinSalary).First()} and {_context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MaxSalary).First()}";
                    return View();
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", employee.DepartmentId);
            ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName", employee.UsersIdUsers);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", employee.DepartmentId);
            ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName", employee.UsersIdUsers);
            ViewData["JobPositionId"] = new SelectList(_context.JobPosition, "IdPosition", "PositionName", employee.JobPositionId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmployee,Documents,FirstName,LastName,DepartmentId,JobPosition,MonthlySalary,UsersIdUsers,JobPositionId")] Employee employee)
        {
            if (id != employee.IdEmployee)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (employee.MonthlySalary > _context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MaxSalary).First() || employee.MonthlySalary< _context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MinSalary).First())
                    {
                        ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", employee.DepartmentId);
                        ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName", employee.UsersIdUsers);
                        ViewBag.ErrorMessage = $"El Salario debe estar comprendido entre {_context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MinSalary).First()} y {_context.JobPosition.Where(x => x.IdPosition == employee.JobPositionId).Select(x => x.MaxSalary).First()}";
                        return View();
                    }
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdEmployee))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "departmentName", employee.DepartmentId);
            ViewData["UsersIdUsers"] = new SelectList(_context.Users, "IdUsers", "UserName", employee.UsersIdUsers);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Users)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdEmployee == id);
        }
    }
}
