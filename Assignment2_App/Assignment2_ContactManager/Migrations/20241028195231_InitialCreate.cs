using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment2_ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    contactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.contactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "contactId", "categoryId", "dateAdded", "email", "firstName", "lastName", "organization", "phoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3113), "johnDoe@gmail.com", "John", "Doe", "Tech Inc.", "123-456-7890" },
                    { 2, 2, new DateTime(2024, 10, 28, 13, 52, 30, 903, DateTimeKind.Local).AddTicks(3150), "alexM@outlook.com", "Alex", "Meyer", null, "345-678-9012" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_categoryId",
                table: "Contacts",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
