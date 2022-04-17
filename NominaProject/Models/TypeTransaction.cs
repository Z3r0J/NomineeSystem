
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class TypeTransaction
    {
        [Key]
        public int IdTypeTransaction { get; set; }
        public string TypeName { get; set; }
    }
}
