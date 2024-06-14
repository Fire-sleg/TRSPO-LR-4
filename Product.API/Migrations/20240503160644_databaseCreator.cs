using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class databaseCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00f68eef-a3b1-4258-9f0c-984af408d10f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("636c5598-0b67-4843-aa95-65762c683292"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9438ac9d-603c-4ed1-a1dd-cdb1bfc3ea85"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("0f5b1d4c-6a7d-42a4-b0df-710754183b5e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("39e17efa-0ea8-4338-a2a7-bd81c719d839"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("4051a325-80f5-4999-ae7b-c7f1c3f9d84b"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Kcal", "Mass", "Name", "NumberOfProducts", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7b89caa2-43d1-4e2f-abb3-4b180151bbee"), new DateTime(2024, 5, 3, 19, 6, 44, 438, DateTimeKind.Local).AddTicks(3715), "Description", 10, 0.0, "Курячі яйця", 0, null },
                    { new Guid("da182d0e-3b4e-459f-888f-89f91097a4cd"), new DateTime(2024, 5, 3, 19, 6, 44, 438, DateTimeKind.Local).AddTicks(3779), "Description", 15, 0.0, "Картопля", 0, null },
                    { new Guid("dd15bc8c-9886-4895-badd-6a70f999ca91"), new DateTime(2024, 5, 3, 19, 6, 44, 438, DateTimeKind.Local).AddTicks(3781), "Description", 25, 0.0, "Цибуля", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageURL", "Name", "ProductIds", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7681376a-fb2f-4c35-b292-f738e3929cb4"), null, "Description", null, "Картопля з цибулею", "[\"da182d0e-3b4e-459f-888f-89f91097a4cd\",\"dd15bc8c-9886-4895-badd-6a70f999ca91\"]", null },
                    { new Guid("8dd58fbd-267e-4030-840b-c9ed45e78fa6"), null, "Description", null, "Яєчня", "[\"7b89caa2-43d1-4e2f-abb3-4b180151bbee\"]", null },
                    { new Guid("9726212e-3182-456a-b97c-0eb7ff0407c3"), null, "Description", null, "Картопля з яйцем та цибулею", "[\"7b89caa2-43d1-4e2f-abb3-4b180151bbee\",\"da182d0e-3b4e-459f-888f-89f91097a4cd\",\"dd15bc8c-9886-4895-badd-6a70f999ca91\"]", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b89caa2-43d1-4e2f-abb3-4b180151bbee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da182d0e-3b4e-459f-888f-89f91097a4cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd15bc8c-9886-4895-badd-6a70f999ca91"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("7681376a-fb2f-4c35-b292-f738e3929cb4"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("8dd58fbd-267e-4030-840b-c9ed45e78fa6"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("9726212e-3182-456a-b97c-0eb7ff0407c3"));

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
    }
}
