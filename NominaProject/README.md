# Sistema de Nóminas
Este es un proyecto de sistema de nóminas que ayuda a gestionar los empleados de una compañia (Sigue en desarrollo, la rama con las actualizaciones mas recientes es "Features")

## Requisitos 📋
[Visual Studio](https://visualstudio.microsoft.com/es/downloads/)
[SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
[Git](https://git-scm.com/downloads)

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



## Ejecutando las pruebas ⚙️
Despues de haber realizado la instalacion asegurese que antes de ejecutar el programa si se encuentra en IIS Express:
> ![](https://i.imgur.com/ScdeaNu.png)
Debe cambiarlo a NominaProject:
![](https://i.imgur.com/aFWkAG3.png)


#### Las tablas que se han creado son las siguientes:
- Department.cs
- Employee.cs
- JobPosition.cs
- Users.cs

Estas se encuentran en la siguiente carpeta: [Models](https://github.com/Z3r0J/NomineeSystem/tree/Views_Design/NominaProject/Models "Models")

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

