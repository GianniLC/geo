using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.Migrations
{
    public partial class ClassChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_User_UserID",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Absence");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Absence",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_UserID",
                table: "Absence",
                newName: "IX_Absence_userID");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfAbsence",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "absenceReason",
                table: "Absence",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_User_userID",
                table: "Absence",
                column: "userID",
                principalTable: "User",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfAbsence",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "absenceReason",
                table: "Absence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Absence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_User_UserID",
                table: "Absence",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
