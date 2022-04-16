using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string departmentName { get; set; }
        public string location { get; set; }
        public string departmentLeader { get; set; }
        public int IdPayroll { get; set; }
        public virtual Payroll Payroll { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<JobPosition> JobPositions { get; set; }


    }
}
