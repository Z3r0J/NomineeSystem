using Microsoft.EntityFrameworkCore.Migrations;

namespace NominaProject.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentLeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollIdPayroll = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Payroll_PayrollIdPayroll",
                        column: x => x.PayrollIdPayroll,
                        principalTable: "Payroll",
                        principalColumn: "IdPayroll",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_PayrollIdPayroll",
                table: "Department",
                column: "PayrollIdPayroll");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
