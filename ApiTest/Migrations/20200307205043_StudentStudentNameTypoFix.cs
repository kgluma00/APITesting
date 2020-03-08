using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTest.Migrations
{
    public partial class StudentStudentNameTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudetName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "StudetName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
