using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class ConvertEducationLevelToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "Employees",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EducationLevel",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");
        }
    }
}
