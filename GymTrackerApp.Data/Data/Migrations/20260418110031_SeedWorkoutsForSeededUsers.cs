using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutsForSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "11111111-2222-3333-4444-555555555555", "A comprehensive workout targeting all major muscle groups.", "Full Body Workout" },
                    { 2, "11111111-2222-3333-4444-555555555555", "Focuses on building strength in the upper body.", "Upper Body" },
                    { 3, "11111111-2222-3333-4444-555555555555", "Targets the lower body muscles for strength and endurance.", "Lower Body" },
                    { 4, "22222222-3333-4444-5555-666666666666", "A comprehensive workout targeting all major muscle groups in the body.", "Full Body" },
                    { 5, "22222222-3333-4444-5555-666666666666", "Focuses on building strength in the pushing muscles.", "Push" },
                    { 6, "22222222-3333-4444-5555-666666666666", "Targets the pulling muscles for strength and endurance.", "Pull" },
                    { 7, "22222222-3333-4444-5555-666666666666", "Focuses on building strength in the leg muscles.", "Legs" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "ExerciseId", "WorkoutId", "Reps", "Sets", "Weight" },
                values: new object[,]
                {
                    { 1, 1, 6, 4, 100.0 },
                    { 4, 1, 10, 3, 50.0 },
                    { 10, 1, 8, 4, 80.0 },
                    { 11, 1, 8, 4, 0.0 },
                    { 20, 2, 8, 4, 60.0 },
                    { 23, 2, 8, 4, 70.0 },
                    { 24, 2, 12, 3, 15.0 },
                    { 28, 2, 10, 3, 35.0 },
                    { 2, 3, 5, 4, 120.0 },
                    { 19, 3, 12, 3, 50.0 },
                    { 30, 3, 10, 3, 40.0 },
                    { 2, 4, 5, 4, 110.0 },
                    { 5, 4, 10, 4, 55.0 },
                    { 12, 4, 15, 4, 0.0 },
                    { 4, 5, 8, 4, 45.0 },
                    { 10, 5, 8, 4, 75.0 },
                    { 21, 5, 12, 3, 25.0 },
                    { 29, 5, 12, 3, 0.0 },
                    { 6, 6, 10, 3, 30.0 },
                    { 11, 6, 8, 4, 0.0 },
                    { 22, 6, 10, 4, 60.0 },
                    { 25, 6, 15, 3, 20.0 },
                    { 1, 7, 6, 4, 95.0 },
                    { 8, 7, 12, 3, 40.0 },
                    { 9, 7, 15, 4, 60.0 },
                    { 32, 7, 8, 4, 80.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 23, 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 28, 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 25, 6 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 32, 7 });

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
