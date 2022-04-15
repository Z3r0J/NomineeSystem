using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Payroll
    {   [Key]
        public int payrollId { get; set; }
        public string pay { get; set; }
    }
}
