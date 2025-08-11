using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "2238b4e3-6d80-4897-92e2-b3fd669e77d0", "admin@bookverse.com", true, false, null, "ADMIN@BOOKVERSE.COM", "ADMIN@BOOKVERSE.COM", "AQAAAAIAAYagAAAAEC9TXINSZGsFZdwnhMbnpQarIMUpXz5pu3SznHJI/9mL42veBtW/v0s2WU40fc1v5Q==", null, false, "08391cf6-8051-45c6-b355-35f6a0823648", false, "admin@bookverse.com" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Thriller" },
                    { 3, "Romance" },
                    { 4, "Sci‑Fi" },
                    { 5, "History" },
                    { 6, "Non‑Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CoverImageUrl", "Description", "GenreId", "PublishedOn", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg", "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.", 1, new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7702), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Whispers of the Mountain" },
                    { 2, "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg", "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.", 2, new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7767), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Shadows in the Fog" },
                    { 3, "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg", "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.", 3, new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7770), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Letters from the Heart" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
