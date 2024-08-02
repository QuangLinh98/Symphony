using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Overview.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleTBDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Topics_TopicID",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TopicID",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TopicID",
                table: "Schedules");

            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Schedules",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TopicID",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TopicID",
                table: "Schedules",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Topics_TopicID",
                table: "Schedules",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID");
        }
    }
}
