using NominaProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NominaProject
{
    public class JobPosition
    {
        [Key]
        public int IdPosition { get; set; }
        [Required]
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string RiskLevel { get; set; }
        public int MaxSalary { get; set; }
        public int MinSalary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}

/*
Identificador
Nombre
Nivel de Riesgo
Nivel Mínimo Salario
Nivel Máximo Salario
*/