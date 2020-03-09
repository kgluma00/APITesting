using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTest.Migrations
{
    public partial class SeedingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName" },
                values: new object[,]
                {
                    { 1, "Programiranje 1" },
                    { 2, "Objektno-orijentirano programiranje" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "SchoolName" },
                values: new object[,]
                {
                    { 1, "Fakultet elektrotehnike, strojarstva i brodogradnje" },
                    { 2, "Fakultet građevinarstva, arhitekture i geodezije" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "SchoolId", "StudentName" },
                values: new object[] { 1, 1, "Josip" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "SchoolId", "StudentName" },
                values: new object[] { 2, 1, "Kristijan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
