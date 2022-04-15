using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Income
    {
        [Key]
        public int incomeId { get; set; } 
        public string incomeName { get; set; }
        public bool apply { get; set; }
        public string state { get; set; }
}
}
