using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Absence",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Absence",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Absence",
                newName: "approved");

            migrationBuilder.AlterColumn<string>(
                name: "approved",
                table: "Absence",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Absence",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Absence",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "approved",
                table: "Absence",
                newName: "Approved");

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Absence",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
