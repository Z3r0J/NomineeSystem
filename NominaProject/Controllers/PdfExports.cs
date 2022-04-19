using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Controllers
{
    public class PdfExports : Controller
    {
        AppDbContext _context;
        public PdfExports(AppDbContext context)
        {
            _context = context;
        }
        // GET: PdfExports
        public ActionResult Index(int id)
        {
            var Total = 0.00;
            foreach (var item in _context.Employees.Where(x=>x.DepartmentId == id))
            {
                var Salary = item.MonthlySalary;
                Total = Total + Salary;
            }

            ViewBag.list = _context.Employees.Include(e=>e.JobPosition).Include(e=>e.Department).Where(x => x.DepartmentId == id).ToList();
            ViewBag.Total = Total;
            ViewBag.DepartmentName = _context.Department.Where(x => x.DepartmentId == id).Select(x=>x.departmentName).First();

            return View(id);
        }
    }
}
