using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class TransactionRegister
    {
        [Key]
        public int IdTransaction { get; set; }
        public int EmployeeIdEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public int IdDeductionOrIncome { get; set; }
        public int TypeTransactionIdTypeTransaction { get; set; }
        public virtual TypeTransaction TypeTransaction { get; set; }
        public DateTime Date { get; set; }
        public long Amount { get; set; }
        public bool State { get; set; }
    }
}
