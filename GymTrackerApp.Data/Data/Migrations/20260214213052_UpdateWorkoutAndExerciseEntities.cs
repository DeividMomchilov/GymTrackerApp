using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkoutAndExerciseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatorId",
                table: "Exercises",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_CreatorId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Exercises");
        }
    }
}
