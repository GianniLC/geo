using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class CommentRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_User_userID",
                table: "Absence");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Absence",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_userID",
                table: "Absence",
                newName: "IX_Absence_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_User_UserID",
                table: "Absence",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_User_UserID",
                table: "Absence");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Absence",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_UserID",
                table: "Absence",
                newName: "IX_Absence_userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_User_userID",
                table: "Absence",
                column: "userID",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
