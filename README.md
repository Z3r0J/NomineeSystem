# Sistema de Nóminas
Este es un proyecto de sistema de nóminas que ayuda a gestionar los empleados de una compañia 

![](https://i.imgur.com/FYMbbnX.png)
> Pagina principal

![](https://i.imgur.com/0ZNScib.png)
>Login

![](https://i.imgur.com/q0jWL55.png)
>Dashboard

![](https://i.imgur.com/OiVuyJj.png)
>Vista de empleados

## Requisitos 📋
- [Visual Studio](https://visualstudio.microsoft.com/es/downloads/)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/downloads)

## Instalación 🔧
1. Clonar el proyacto usando Git ejecutando:
` git clone https://github.com/Z3r0J/NomineeSystem.git`

2. Abrir la solucion del proyecto en Visual Studio.
3. Abrir el appsettings.json y reemplazar la linea siguiente.
```json
 "DefaultConnection": "Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=NomineeProject;Integrated Security=True;Pooling=False"
```
Reemplazando '(localdb)\\MSSQLLOCALDB' con tu conexion de SQL Server.

4. Abrir en Visual Studio el Package Manager Console y ejecutar estas lineas de comando
`Add-Migration`
`Update-Database`
5. Abrir SQL Server Buscar la base de datos creada y agregar un usuario y asignar ese usuario a un empleado luego iniciar sesion

> Nota:  Si tiene problemas al realizar las migraciones puede ejecutar los scripts de 'NomineeSQL.sql' para obtener la base de datos.



## Ejecutando las pruebas ⚙️
Despues de haber realizado la instalacion asegurese que antes de ejecutar el programa si se encuentra en IIS Express:
> ![](https://i.imgur.com/ScdeaNu.png)
Debe cambiarlo a NominaProject:
![](https://i.imgur.com/aFWkAG3.png)

#### Las modelos que se han creado son las siguientes:
- Deduction.cs
- Department.cs
- Employee.cs
- ErrorViewMode.cs
- GetNameAndLastName.cs
- Income.cs
- JobPosition.cs
- Payroll.cs
- TransactionRegister.cs
- TransactionRegister.cs
- Users.cs

Estas se encuentran en la siguiente carpeta: [Models](https://github.com/Z3r0J/NomineeSystem/tree/Views_Design/NominaProject/Models "Models")

##### Deduction:
```csharp
public class Deduction
    {
        [Key]
        public int IdDeduction { get; set; }
        public string DeductionName { get; set; }
        public bool Apply { get; set; }
        public char State { get; set; }
    }

```

##### Department:

```csharp
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string departmentName { get; set; }
        public string location { get; set; }
        public string departmentLeader { get; set; }
        public int IdPayroll { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<JobPosition> JobPositions { get; set; }
    }
```

##### Employee:
```csharp
public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        [Required]
        public string Documents { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public double MonthlySalary { get; set; }
        public int UsersIdUsers { get; set; }
        public virtual Users Users { get; set; }
        public static bool IsLogged { get; set; } 
    }
```
##### ErrorViewModel:
```csharp
public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
```
##### GetNameAndLastName:
```csharp
public class GetNameAndLastName
    {
        public static string Name { get; set; }
        public static string LastName { get; set; }
        public static List<double> NetSalary { get; set; } = new List<double>();
    }
```
##### Income:
```csharp
    public class Income
    {
        [Key]
        public int incomeId { get; set; } 
        public string incomeName { get; set; }
        public bool apply { get; set; }
        public string state { get; set; }
    }
```
##### JobPosition:
```csharp
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
```
##### Payroll:
```csharp
public class Payroll
    {   [Key]
        public int IdPayroll { get; set; }
        public string payName { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
```
##### TransactionRegister:
```csharp
public class TransactionRegister
    {
        [Key]
        public int IdTransaction { get; set; }
        public int IdEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public int IdDeductionOrIncome { get; set; }
        public int IdTypeTransaction { get; set; }
        public virtual TypeTransaction TypeTransaction { get; set; }
        public DateTime Date { get; set; }
        public long Amount { get; set; }
        public bool State { get; set; }
    }
```
##### TypeTransaction:
```csharp
public class TypeTransaction
    {
        [Key]
        public int IdTypeTransaction { get; set; }
        public string TypeName { get; set; }
    }
```
##### Users:

```csharp
public class Users
    {
        [Key]
        public int IdUsers { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
```

## Construido con 🛠️
- Patron de diseño MVC
- ASP.NET Core
- Entity Framework
- SQL Server
## Autores ✒️
- Junior Sánchez  
- Francisco Medina
- Jean Carlos Reyes


## ----------------------------------------

 Creado con ❤️ por [Junior06sre](https://github.com/Junior06sre) 😊
 
