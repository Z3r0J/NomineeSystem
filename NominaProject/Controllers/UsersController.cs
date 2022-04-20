using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NominaProject.Data;
using NominaProject.Models;
using System.Web;

namespace NominaProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public static Employee Employee;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DashBoard() {
            ViewData["NomineeTotal"] = _context.Employees.Select(x=>x.MonthlySalary).Sum();
            ViewData["NumberDepartment"] = _context.Department.Select(x => x.DepartmentId).Count();
            ViewData["NumberEmployees"] = _context.Employees.Select(x => x.IdEmployee).Count();
            ViewData["TransactionTotal"] = _context.TransactionRegister.Select(x => x.Amount).Sum();
            var count = _context.Employees.
                Include(e => e.Department).ToList().
                GroupBy(e => e.Department.departmentName).
                Select(y => new DashBoardInfo{ Department = y.Key, count = y.Count() }).
                OrderByDescending(y=>y.count).First();

            ViewData["BiggestDepartment"] = $"{count.Department} - {count.count}";
            ViewData["NumberTransaction"] = _context.TransactionRegister.Select(x => x.IdTransaction).Count();

            return View();
        }

        // POST: Users
        [HttpPost]
        public ActionResult Login(Users us)
        {
            try
            {
                using (AppDbContext dbContext = _context)
                {
                    //var user = from d in dbContext.Users
                    //           where d.UserName == us.UserName && d.Password == us.Password
                    //           select d;

                    var lst = from d in dbContext.Employees
                              join s in dbContext.Users
                              on d.Users.IdUsers equals s.IdUsers
                              where s.UserName == us.UserName && s.Password == us.Password
                              select new
                              {
                              d.IdEmployee,
                              d.FirstName,
                              d.LastName
                              };
                    if (lst.Count()>0)
                    {
                        Employee = new Employee {
                            IdEmployee = lst.First().IdEmployee,
                            FirstName = lst.First().FirstName,
                            LastName = lst.First().LastName,
                        };
                        Employee.IsLogged = true;
                        GetNameAndLastName.Name = lst.First().FirstName;
                        GetNameAndLastName.LastName = lst.First().LastName;
                        return RedirectToAction("Index","Employees");
                    }
                    else
                    { 
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Logout() {
            Employee.IsLogged = false;
            GetNameAndLastName.Name = "";
            GetNameAndLastName.LastName = "";

            return RedirectToAction("Index","Home");
        
        }
    }
}
