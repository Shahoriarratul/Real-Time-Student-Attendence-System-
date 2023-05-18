using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendence_System.Migrations
{
    public partial class AddAttendence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastClssDay",
                table: "Courses",
                newName: "ThirdClssDay");

            migrationBuilder.RenameColumn(
                name: "LastClassTime",
                table: "Courses",
                newName: "ThirdClassTime");

            migrationBuilder.AddColumn<string>(
                name: "SecondClassTime",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondClssDay",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Attendences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendences_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_CourseID",
                table: "Attendences",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendences");

            migrationBuilder.DropColumn(
                name: "SecondClassTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SecondClssDay",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ThirdClssDay",
                table: "Courses",
                newName: "LastClssDay");

            migrationBuilder.RenameColumn(
                name: "ThirdClassTime",
                table: "Courses",
                newName: "LastClassTime");
        }
    }
}
