using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseRegistrationTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Courses_CourseId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Students_StudentId",
                table: "CourseRegistrations");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseRegistrations",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseRegistrations",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_StudentId",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_CourseId",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Courses_CourseID",
                table: "CourseRegistrations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Students_StudentID",
                table: "CourseRegistrations",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Courses_CourseID",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Students_StudentID",
                table: "CourseRegistrations");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "CourseRegistrations",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseRegistrations",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_StudentID",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegistrations_CourseID",
                table: "CourseRegistrations",
                newName: "IX_CourseRegistrations_CourseId");

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
    }
}
