using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KYC360_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Deceased = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Names_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "Id", "Deceased", "Gender" },
                values: new object[,]
                {
                    { "1", false, "Male" },
                    { "2", true, "Female" },
                    { "3", false, "Male" },
                    { "4", true, "Female" },
                    { "5", false, "Male" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine", "City", "Country", "EntityId" },
                values: new object[,]
                {
                    { 1, "123 Park Street", "Kolkata", "India", "1" },
                    { 2, "456 MG Road", "Mumbai", "India", "2" },
                    { 3, "789 Lake Road", "Chennai", "India", "3" },
                    { 4, "101 Hill Avenue", "Bangalore", "India", "4" },
                    { 5, "222 River Side", "Hyderabad", "India", "5" }
                });

            migrationBuilder.InsertData(
                table: "Dates",
                columns: new[] { "Id", "DateType", "DateValue", "EntityId" },
                values: new object[,]
                {
                    { 1, "Birth", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { 2, "Death", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "2" },
                    { 3, "Birth", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "3" },
                    { 4, "Death", new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "4" },
                    { 5, "Birth", new DateTime(1978, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" }
                });

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "Id", "EntityId", "FirstName", "MiddleName", "Surname" },
                values: new object[,]
                {
                    { 1, "1", "Ravi", "Kumar", "Singh" },
                    { 2, "2", "Sneha", "Rani", "Gupta" },
                    { 3, "3", "Amit", "Kumar", "Sharma" },
                    { 4, "4", "Priya", "Devi", "Verma" },
                    { 5, "5", "Vikram", "Singh", "Yadav" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EntityId",
                table: "Addresses",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_EntityId",
                table: "Dates",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Names_EntityId",
                table: "Names",
                column: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
