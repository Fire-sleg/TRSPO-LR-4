using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserAPI.Migrations
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
                keyValue: new Guid("0463431c-2f71-4ffb-a908-d6b5044b74e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("35ec7399-15aa-4b88-88e2-418fe38209dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1404200-c96e-4d77-9d8a-c5a3c6eb8063"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("0e9d3a5c-71bc-4847-bca7-ab0b1f9a0b85"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("75b974d1-e2be-4714-b9c2-8e5fd3dd1fc9"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e9c679aa-cb3d-44ce-bb7a-3c88abbef149"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Kcal", "Mass", "Name", "NumberOfProducts", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("05cbf9f0-959e-465a-8059-48a0f232d5c1"), new DateTime(2024, 5, 3, 19, 7, 40, 588, DateTimeKind.Local).AddTicks(647), "Description", 10, 0.0, "Курячі яйця", 0, null },
                    { new Guid("74e92459-af85-4c35-8be1-f3d8a5cbc50b"), new DateTime(2024, 5, 3, 19, 7, 40, 588, DateTimeKind.Local).AddTicks(904), "Description", 25, 0.0, "Цибуля", 0, null },
                    { new Guid("a3efdc48-6efc-4fcf-97d9-00659f8b90df"), new DateTime(2024, 5, 3, 19, 7, 40, 588, DateTimeKind.Local).AddTicks(718), "Description", 15, 0.0, "Картопля", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageURL", "Name", "ProductIds", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e15f14a-174d-407c-8d0d-1163c01ac213"), null, "Description", null, "Картопля з цибулею", "[\"a3efdc48-6efc-4fcf-97d9-00659f8b90df\",\"74e92459-af85-4c35-8be1-f3d8a5cbc50b\"]", null },
                    { new Guid("456ad79d-2561-4039-a83a-4c98d7bfffaf"), null, "Description", null, "Картопля з яйцем та цибулею", "[\"05cbf9f0-959e-465a-8059-48a0f232d5c1\",\"a3efdc48-6efc-4fcf-97d9-00659f8b90df\",\"74e92459-af85-4c35-8be1-f3d8a5cbc50b\"]", null },
                    { new Guid("95120bde-4548-4a4b-9faf-89f03f55553b"), null, "Description", null, "Яєчня", "[\"05cbf9f0-959e-465a-8059-48a0f232d5c1\"]", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05cbf9f0-959e-465a-8059-48a0f232d5c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74e92459-af85-4c35-8be1-f3d8a5cbc50b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3efdc48-6efc-4fcf-97d9-00659f8b90df"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("0e15f14a-174d-407c-8d0d-1163c01ac213"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("456ad79d-2561-4039-a83a-4c98d7bfffaf"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("95120bde-4548-4a4b-9faf-89f03f55553b"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Kcal", "Mass", "Name", "NumberOfProducts", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0463431c-2f71-4ffb-a908-d6b5044b74e2"), new DateTime(2024, 5, 3, 19, 2, 26, 834, DateTimeKind.Local).AddTicks(9545), "Description", 15, 0.0, "Картопля", 0, null },
                    { new Guid("35ec7399-15aa-4b88-88e2-418fe38209dc"), new DateTime(2024, 5, 3, 19, 2, 26, 834, DateTimeKind.Local).AddTicks(9490), "Description", 10, 0.0, "Курячі яйця", 0, null },
                    { new Guid("b1404200-c96e-4d77-9d8a-c5a3c6eb8063"), new DateTime(2024, 5, 3, 19, 2, 26, 834, DateTimeKind.Local).AddTicks(9576), "Description", 25, 0.0, "Цибуля", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageURL", "Name", "ProductIds", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e9d3a5c-71bc-4847-bca7-ab0b1f9a0b85"), null, "Description", null, "Картопля з яйцем та цибулею", "[\"35ec7399-15aa-4b88-88e2-418fe38209dc\",\"0463431c-2f71-4ffb-a908-d6b5044b74e2\",\"b1404200-c96e-4d77-9d8a-c5a3c6eb8063\"]", null },
                    { new Guid("75b974d1-e2be-4714-b9c2-8e5fd3dd1fc9"), null, "Description", null, "Картопля з цибулею", "[\"0463431c-2f71-4ffb-a908-d6b5044b74e2\",\"b1404200-c96e-4d77-9d8a-c5a3c6eb8063\"]", null },
                    { new Guid("e9c679aa-cb3d-44ce-bb7a-3c88abbef149"), null, "Description", null, "Яєчня", "[\"35ec7399-15aa-4b88-88e2-418fe38209dc\"]", null }
                });
        }
    }
}
