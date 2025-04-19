using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCompanyDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigRealationBetweentEmpAndDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "empolyees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_empolyees_DepartmentId",
                table: "empolyees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_empolyees_Departments_DepartmentId",
                table: "empolyees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empolyees_Departments_DepartmentId",
                table: "empolyees");

            migrationBuilder.DropIndex(
                name: "IX_empolyees_DepartmentId",
                table: "empolyees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "empolyees");
        }
    }
}
