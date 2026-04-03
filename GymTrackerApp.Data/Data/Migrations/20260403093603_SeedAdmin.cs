using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTrackerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3026ea73-023b-4901-b63b-ca12cd6fe019" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-2222-3333-4444-555555555555", 0, "admin-concurrency-stamp-1234", "admin@gymtracker.com", true, false, null, "ADMIN@GYMTRACKER.COM", "ADMIN@GYMTRACKER.COM", "AQAAAAIAAYagAAAAEPLDGkgokSex9Yy1N5AotosXTKzXUPHYrSNKcQcDYfceG9Ij9w8333qqlMv4UWKvcQ==", null, false, "admin-security-stamp-1234", false, "admin@gymtracker.com" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatorId",
                value: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "11111111-2222-3333-4444-555555555555" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "11111111-2222-3333-4444-555555555555" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-2222-3333-4444-555555555555");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "3026ea73-023b-4901-b63b-ca12cd6fe019" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatorId",
                value: "3026ea73-023b-4901-b63b-ca12cd6fe019");
        }
    }
}
