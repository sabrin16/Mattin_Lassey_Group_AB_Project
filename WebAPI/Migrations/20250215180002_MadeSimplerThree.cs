using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class MadeSimplerThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusType",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Projects",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Projects",
                newName: "EndDate");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Projects",
                newName: "endDate");

            migrationBuilder.AddColumn<string>(
                name: "StatusType",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
