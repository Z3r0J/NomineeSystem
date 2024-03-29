﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NominaProject.Models;
using NominaProject;

namespace NominaProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NominaProject.Models.Employee> Employees { get; set; }

        public DbSet<NominaProject.Models.Users> Users { get; set; }

        public DbSet<NominaProject.Models.Department> Department { get; set; }
        public DbSet<NominaProject.Models.Deduction> Deduction { get; set; }
        public DbSet<NominaProject.Models.Income> Income { get; set; }
        public DbSet<NominaProject.Models.Payroll> Payroll { get; set; }
        public DbSet<NominaProject.JobPosition> JobPosition { get; set; }
        public DbSet<NominaProject.Models.TypeTransaction> TypeTransaction { get; set; }
        public DbSet<NominaProject.Models.TransactionRegister> TransactionRegister { get; set; }



    }
}
