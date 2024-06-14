using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcal = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    NumberOfProducts = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Kcal", "Mass", "Name", "NumberOfProducts", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00f68eef-a3b1-4258-9f0c-984af408d10f"), new DateTime(2024, 5, 3, 19, 1, 39, 786, DateTimeKind.Local).AddTicks(5671), "Description", 25, 0.0, "Цибуля", 0, null },
                    { new Guid("636c5598-0b67-4843-aa95-65762c683292"), new DateTime(2024, 5, 3, 19, 1, 39, 786, DateTimeKind.Local).AddTicks(5667), "Description", 15, 0.0, "Картопля", 0, null },
                    { new Guid("9438ac9d-603c-4ed1-a1dd-cdb1bfc3ea85"), new DateTime(2024, 5, 3, 19, 1, 39, 786, DateTimeKind.Local).AddTicks(5573), "Description", 10, 0.0, "Курячі яйця", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageURL", "Name", "ProductIds", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0f5b1d4c-6a7d-42a4-b0df-710754183b5e"), null, "Description", null, "Картопля з яйцем та цибулею", "[\"9438ac9d-603c-4ed1-a1dd-cdb1bfc3ea85\",\"636c5598-0b67-4843-aa95-65762c683292\",\"00f68eef-a3b1-4258-9f0c-984af408d10f\"]", null },
                    { new Guid("39e17efa-0ea8-4338-a2a7-bd81c719d839"), null, "Description", null, "Яєчня", "[\"9438ac9d-603c-4ed1-a1dd-cdb1bfc3ea85\"]", null },
                    { new Guid("4051a325-80f5-4999-ae7b-c7f1c3f9d84b"), null, "Description", null, "Картопля з цибулею", "[\"636c5598-0b67-4843-aa95-65762c683292\",\"00f68eef-a3b1-4258-9f0c-984af408d10f\"]", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
