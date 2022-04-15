using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Deduction
    {
        [Key]
        public int IdDeduction { get; set; }
        public string DeductionName { get; set; }
        public bool Apply { get; set; }
        public char State { get; set; }
    }
}
