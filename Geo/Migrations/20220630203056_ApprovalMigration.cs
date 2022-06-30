using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class ApprovalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Absence",
                type: "bit",
                nullable: true,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Absence");
        }
    }
}
