using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Deduction
    {
        public int IdDeduction { get; set; }
        public string DeductionName { get; set; }
        public bool Apply { get; set; }
        public char State { get; set; }
    }
}
