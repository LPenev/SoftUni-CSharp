using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Horizons.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7699db7d-964f-4782-8209-d76562e0fece", 0, "8f4a65f8-f909-466f-a00f-568eb9e9c981", "admin@horizons.com", true, false, null, "ADMIN@HORIZONS.COM", "ADMIN@HORIZONS.COM", "AQAAAAIAAYagAAAAEP3DsN0ILPEiU3+NqLIjfb5xzv08pZjCOW5JLBsTXdmKWsZLXEfMUqFPy4NsKERvTQ==", null, false, "ccda36c1-289b-4515-b65c-39c47a8c03cc", false, "admin@horizons.com" });

            migrationBuilder.InsertData(
                table: "Terrains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mountain" },
                    { 2, "Beach" },
                    { 3, "Forest" },
                    { 4, "Plain" },
                    { 5, "Urban" },
                    { 6, "Village" },
                    { 7, "Cave" },
                    { 8, "Canyon" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "Name", "PublishedOn", "PublisherId", "TerrainId" },
                values: new object[,]
                {
                    { 1, "A stunning historical landmark nestled in the Rila Mountains.", "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg", false, "Rila Monastery", new DateTime(2025, 6, 18, 14, 20, 30, 616, DateTimeKind.Local).AddTicks(5425), "7699db7d-964f-4782-8209-d76562e0fece", 1 },
                    { 2, "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.", "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp", false, "Durankulak Beach", new DateTime(2025, 6, 18, 14, 20, 30, 616, DateTimeKind.Local).AddTicks(5481), "7699db7d-964f-4782-8209-d76562e0fece", 2 },
                    { 3, "A mysterious cave located in the Rhodope Mountains.", "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg", false, "Devil's Throat Cave", new DateTime(2025, 6, 18, 14, 20, 30, 616, DateTimeKind.Local).AddTicks(5484), "7699db7d-964f-4782-8209-d76562e0fece", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece");

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Terrains",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
