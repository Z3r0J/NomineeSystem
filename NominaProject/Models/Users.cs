using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject.Models
{
    public class Users
    {
        [Key]
        public int IdUsers { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
