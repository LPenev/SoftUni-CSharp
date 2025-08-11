using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameUsersBooksToUsersBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "222a01ee-6c6b-4ca5-a829-7bcdcd2f6390", "AQAAAAIAAYagAAAAEHPpyoGOvAxrZ4SN4DzjOYDWJMhLFKRhz1HPthCbYvLaUYRUmHW+1kC4nw8vk4QW0w==", "d8aa0283-57a3-4158-97c4-b02f99d6ac19" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 11, 48, 5, 4, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 11, 48, 5, 4, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 11, 48, 5, 4, DateTimeKind.Local).AddTicks(1556));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2238b4e3-6d80-4897-92e2-b3fd669e77d0", "AQAAAAIAAYagAAAAEC9TXINSZGsFZdwnhMbnpQarIMUpXz5pu3SznHJI/9mL42veBtW/v0s2WU40fc1v5Q==", "08391cf6-8051-45c6-b355-35f6a0823648" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2025, 8, 11, 10, 4, 49, 134, DateTimeKind.Local).AddTicks(7770));
        }
    }
}
