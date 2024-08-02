using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusInCourseRegistrationTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistration_Courses_CourseId",
                table: "CourseRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistration_Students_StudentId",
                table: "CourseRegistration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegistration",
                table: "CourseRegistration");

            migrationBuilder.RenameTable(
                name: "CourseRegistration",
                newName: "CourseRegistrations");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistration_StudentId",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistration_CourseId",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CourseRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegistrations",
                table: "CourseRegistrations",
                column: "CourseRegistrationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Courses_CourseId",
                table: "CourseRegistrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Students_StudentId",
                table: "CourseRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Courses_CourseId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Students_StudentId",
                table: "CourseRegistrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegistrations",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseRegistrations");

            migrationBuilder.RenameTable(
                name: "CourseRegistrations",
                newName: "CourseRegistration");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_StudentId",
                table: "CourseRegistration",
                newName: "IX_CourseRegistration_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_CourseId",
                table: "CourseRegistration",
                newName: "IX_CourseRegistration_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegistration",
                table: "CourseRegistration",
                column: "CourseRegistrationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistration_Courses_CourseId",
                table: "CourseRegistration",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistration_Students_StudentId",
                table: "CourseRegistration",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
