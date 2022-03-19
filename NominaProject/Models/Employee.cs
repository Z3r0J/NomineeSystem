﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string Documents { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public int JobPosition { get; set; }
        public double MonthlySalary { get; set; }
        public Users Users { get; set; }
        public static bool IsLogged { get; set; } 
    }
}
