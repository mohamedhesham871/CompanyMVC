using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCompanyDataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageCoulmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "empolyees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "empolyees");
        }
    }
}
