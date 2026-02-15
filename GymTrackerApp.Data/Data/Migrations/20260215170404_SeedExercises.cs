using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatorId", "Description", "ImageUrl", "MuscleId", "Name" },
                values: new object[,]
                {
                    { 1, "3026ea73-023b-4901-b63b-ca12cd6fe019", "The king of leg exercises. Targets quads, hamstrings, and glutes.", "https://example.com/squat.jpg", 13, "Squat" },
                    { 2, "3026ea73-023b-4901-b63b-ca12cd6fe019", "A compound movement that works the entire posterior chain.", "https://example.com/deadlift.jpg", 3, "Deadlift" },
                    { 4, "3026ea73-023b-4901-b63b-ca12cd6fe019", "A classic shoulder builder performed with a barbell.", "https://example.com/ohp.jpg", 6, "Overhead Press" },
                    { 5, "3026ea73-023b-4901-b63b-ca12cd6fe019", "A machine exercise that targets the latissimus dorsi.", "https://example.com/latpulldown.jpg", 4, "Lat Pulldown" },
                    { 6, "3026ea73-023b-4901-b63b-ca12cd6fe019", "An isolation exercise for the biceps.", "https://example.com/bicepcurl.jpg", 7, "Barbell Curl" },
                    { 7, "3026ea73-023b-4901-b63b-ca12cd6fe019", "An isolation exercise for the triceps using a cable machine.", "https://example.com/triceppushdown.jpg", 8, "Tricep Rope Pushdown" },
                    { 8, "3026ea73-023b-4901-b63b-ca12cd6fe019", "Isolation exercise for the hamstrings.", "https://example.com/legcurl.jpg", 14, "Leg Curl" },
                    { 9, "3026ea73-023b-4901-b63b-ca12cd6fe019", "Simple but effective exercise for building calves.", "https://example.com/calfraise.jpg", 16, "Calf Raise" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
