using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExercisesAndDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22222222-3333-4444-5555-666666666666", 0, "testuser-concurrency-stamp-1234", "testuser123@gymtracker.com", true, false, null, "TESTUSER123@GYMTRACKER.COM", "TESTUSER123", "AQAAAAIAAYagAAAAEPLDGkgokSex9Yy1N5AotosXTKzXUPHYrSNKcQcDYfceG9Ij9w8333qqlMv4UWKvcQ==", null, false, "testuser-security-stamp-1234", false, "TestUser123" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatorId", "Description", "ImageUrl", "MuscleId", "Name" },
                values: new object[,]
                {
                    { 10, "11111111-2222-3333-4444-555555555555", "The ultimate chest builder. A compound push exercise using a barbell.", "https://example.com/benchpress.jpg", 1, "Bench Press" },
                    { 11, "11111111-2222-3333-4444-555555555555", "A bodyweight exercise that builds upper back and lat width.", "https://example.com/pullup.jpg", 2, "Pull-up" },
                    { 12, "11111111-2222-3333-4444-555555555555", "A classic bodyweight exercise for chest, shoulders, and triceps.", "https://example.com/pushup.jpg", 1, "Push-up" },
                    { 13, "11111111-2222-3333-4444-555555555555", "An isolation exercise to build the upper trapezius muscles.", "https://example.com/shrugs.jpg", 5, "Dumbbell Shrugs" },
                    { 14, "11111111-2222-3333-4444-555555555555", "An isolation exercise for forearm size and grip strength.", "https://example.com/wristcurl.jpg", 9, "Wrist Curls" },
                    { 15, "11111111-2222-3333-4444-555555555555", "A basic core exercise targeting the upper abdominal muscles.", "https://example.com/crunches.jpg", 10, "Crunches" },
                    { 16, "11111111-2222-3333-4444-555555555555", "An advanced core exercise primarily targeting the lower abs.", "https://example.com/legraises.jpg", 11, "Hanging Leg Raises" },
                    { 17, "11111111-2222-3333-4444-555555555555", "A core exercise designed to target the oblique muscles.", "https://example.com/russiantwist.jpg", 12, "Russian Twists" },
                    { 18, "11111111-2222-3333-4444-555555555555", "The best exercise for isolating and building the glutes.", "https://example.com/hipthrust.jpg", 15, "Hip Thrusts" },
                    { 19, "11111111-2222-3333-4444-555555555555", "A machine isolation exercise specifically for the quadriceps.", "https://example.com/legextension.jpg", 13, "Leg Extension" },
                    { 20, "11111111-2222-3333-4444-555555555555", "Excellent for targeting the upper portion of the pectoral muscles.", "https://example.com/inclinepress.jpg", 1, "Incline Dumbbell Press" },
                    { 21, "11111111-2222-3333-4444-555555555555", "An isolation exercise that provides constant tension on the chest.", "https://example.com/cablecrossover.jpg", 1, "Cable Crossover" },
                    { 22, "11111111-2222-3333-4444-555555555555", "Builds middle back thickness and improves posture.", "https://example.com/cablerow.jpg", 2, "Seated Cable Row" },
                    { 23, "11111111-2222-3333-4444-555555555555", "A heavy compound pulling exercise for mass in the lats and mid-back.", "https://example.com/tbarrow.jpg", 4, "T-Bar Row" },
                    { 24, "11111111-2222-3333-4444-555555555555", "The best exercise for isolating the side deltoids to build wider shoulders.", "https://example.com/lateralraise.jpg", 6, "Lateral Raise" },
                    { 25, "11111111-2222-3333-4444-555555555555", "Crucial for rear deltoid development and overall shoulder health.", "https://example.com/facepull.jpg", 6, "Face Pulls" },
                    { 26, "11111111-2222-3333-4444-555555555555", "Targets the brachialis and the brachioradialis for thicker arms.", "https://example.com/hammercurl.jpg", 7, "Hammer Curl" },
                    { 27, "11111111-2222-3333-4444-555555555555", "Strict isolation for the biceps, preventing momentum.", "https://example.com/preachercurl.jpg", 7, "Preacher Curl" },
                    { 28, "11111111-2222-3333-4444-555555555555", "A barbell extension movement that heavily targets the long head of the triceps.", "https://example.com/skullcrusher.jpg", 8, "Skull Crushers" },
                    { 29, "11111111-2222-3333-4444-555555555555", "A heavy compound bodyweight movement for thick triceps and chest.", "https://example.com/dips.jpg", 8, "Tricep Dips" },
                    { 30, "11111111-2222-3333-4444-555555555555", "A unilateral leg exercise that builds immense quad and glute strength.", "https://example.com/splitsquat.jpg", 13, "Bulgarian Split Squat" },
                    { 31, "11111111-2222-3333-4444-555555555555", "A machine variation of the squat that isolates the quads effectively.", "https://example.com/hacksquat.jpg", 13, "Hack Squat" },
                    { 32, "11111111-2222-3333-4444-555555555555", "Focuses entirely on the hamstrings and glutes through a hip hinge.", "https://example.com/rdl.jpg", 14, "Romanian Deadlift (RDL)" },
                    { 33, "11111111-2222-3333-4444-555555555555", "Builds immense lower back, glute, and hamstring strength.", "https://example.com/goodmorning.jpg", 3, "Good Mornings" },
                    { 34, "11111111-2222-3333-4444-555555555555", "Targets the soleus muscle of the calves.", "https://example.com/seatedcalf.jpg", 16, "Seated Calf Raise" },
                    { 35, "11111111-2222-3333-4444-555555555555", "A full-body carry that builds extreme grip strength and traps.", "https://example.com/farmerswalk.jpg", 9, "Farmer's Walk" },
                    { 36, "11111111-2222-3333-4444-555555555555", "An isometric core exercise that builds endurance and stability.", "https://example.com/plank.jpg", 10, "Plank" },
                    { 37, "11111111-2222-3333-4444-555555555555", "Dynamic movement hitting both the rectus abdominis and obliques.", "https://example.com/bicycle.jpg", 12, "Bicycle Crunches" },
                    { 38, "11111111-2222-3333-4444-555555555555", "Rotational core movement perfect for athletic performance and obliques.", "https://example.com/woodchopper.jpg", 12, "Cable Woodchoppers" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "22222222-3333-4444-5555-666666666666" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "22222222-3333-4444-5555-666666666666" });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-3333-4444-5555-666666666666");

            migrationBuilder.InsertData(
                table: "Muscles",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 17, "Various muscles supporting the cervical spine, responsible for rotating and bending the head.", "https://placehold.co/600x400/212529/0dcaf0?text=Neck", "Neck" });
        }
    }
}
