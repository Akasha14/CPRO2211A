using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2_ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class AddContactSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "name" },
                values: new object[] { 4, "Other" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "contactId",
                keyValue: 1,
                column: "dateAdded",
                value: new DateTime(2024, 10, 28, 21, 13, 11, 638, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "contactId",
                keyValue: 2,
                column: "dateAdded",
                value: new DateTime(2024, 10, 28, 21, 13, 11, 638, DateTimeKind.Local).AddTicks(113));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "categoryId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "contactId",
                keyValue: 1,
                column: "dateAdded",
                value: new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "contactId",
                keyValue: 2,
                column: "dateAdded",
                value: new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3150));
        }
    }
}
