using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    daysVacation = table.Column<int>(type: "int", nullable: true),
                    daysSick = table.Column<int>(type: "int", nullable: true),
                    daysPersonal = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
