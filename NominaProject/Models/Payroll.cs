using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Payroll
    {   [Key]
        public int IdPayroll { get; set; }
        public string payName { get; set; }

        public virtual ICollection<Department> Department { get; set; }

    }
}
