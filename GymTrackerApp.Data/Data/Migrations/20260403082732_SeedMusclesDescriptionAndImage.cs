using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMusclesDescriptionAndImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The pectoralis major makes up the bulk of the chest muscles. It is responsible for movement of the shoulder joint and arms across the body.", "https://placehold.co/600x400/212529/0dcaf0?text=Chest" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Includes the rhomboids and upper latissimus dorsi. These muscles pull the shoulder blades together and help maintain proper posture.", "https://placehold.co/600x400/212529/0dcaf0?text=Upper+Back" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The erector spinae muscles support the spine and allow for extending the back. Crucial for core stability and lifting.", "https://placehold.co/600x400/212529/0dcaf0?text=Lower+Back" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The latissimus dorsi is the largest muscle in the upper body, responsible for pulling actions and giving the back its V-taper.", "https://placehold.co/600x400/212529/0dcaf0?text=Lats" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The trapezius muscles run down the neck and middle back. They elevate and depress the shoulder blades.", "https://placehold.co/600x400/212529/0dcaf0?text=Traps" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The deltoids consist of three heads (anterior, lateral, and posterior) that allow the arms to lift and rotate in all directions.", "https://placehold.co/600x400/212529/0dcaf0?text=Shoulders" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The biceps brachii sits on the front of the upper arm and is responsible for elbow flexion (curling) and forearm rotation.", "https://placehold.co/600x400/212529/0dcaf0?text=Biceps" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The triceps brachii makes up about 2/3 of the upper arm's mass. It consists of three heads responsible for extending the elbow.", "https://placehold.co/600x400/212529/0dcaf0?text=Triceps" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A complex group of smaller muscles responsible for grip strength, wrist flexion, and extension.", "https://placehold.co/600x400/212529/0dcaf0?text=Forearms" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "The rectus abdominis is the front core muscle layer. It flexes the spine and provides essential core stabilization.", "https://placehold.co/600x400/212529/0dcaf0?text=Abs", "Abs" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Situated on the sides of the abdomen, these muscles handle rotational movements and lateral flexion of the torso.", "https://placehold.co/600x400/212529/0dcaf0?text=Obliques", "Obliques" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "The gluteus maximus is one of the strongest muscles in the human body, serving as the main extensor of the hip.", "https://placehold.co/600x400/212529/0dcaf0?text=Glutes", "Glutes" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The quadriceps femoris consists of four large muscles on the front of the thigh that extend the knee.", "https://placehold.co/600x400/212529/0dcaf0?text=Quads" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Located on the back of the thigh, these muscles are responsible for knee flexion and assist in hip extension.", "https://placehold.co/600x400/212529/0dcaf0?text=Hamstrings" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "The inner thigh muscles that pull the legs together toward the midline of the body.", "https://placehold.co/600x400/212529/0dcaf0?text=Adductors", "Adductors" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Consisting of the gastrocnemius and soleus, these lower leg muscles act to flex the foot and ankle.", "https://placehold.co/600x400/212529/0dcaf0?text=Calves" });

            migrationBuilder.InsertData(
                table: "Muscles",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 17, "Various muscles supporting the cervical spine, responsible for rotating and bending the head.", "https://placehold.co/600x400/212529/0dcaf0?text=Neck", "Neck" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Upper Abs" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Lower Abs" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Obliques" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Glutes" });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });
        }
    }
}
