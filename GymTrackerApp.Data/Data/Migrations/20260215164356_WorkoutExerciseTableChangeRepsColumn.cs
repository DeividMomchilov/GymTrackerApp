using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutExerciseTableChangeRepsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Repetitions",
                table: "WorkoutExercises",
                newName: "Reps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reps",
                table: "WorkoutExercises",
                newName: "Repetitions");
        }
    }
}
