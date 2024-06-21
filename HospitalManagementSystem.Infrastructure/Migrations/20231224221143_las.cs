using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class las : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visit_BillId",
                table: "Visit");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8c6b768e-e290-4c28-b19a-1332ed7ab36c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("df5dd338-2d1c-41c6-b738-d1b554befd03"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("190da905-55ba-430a-aac1-7bdc15da43ac"), "Dentistry" },
                    { new Guid("ceec788e-98a4-45c1-86e2-a5d4c4b4f22a"), "Childcare" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_BillId",
                table: "Visit",
                column: "BillId",
                unique: true,
                filter: "[BillId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visit_BillId",
                table: "Visit");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("190da905-55ba-430a-aac1-7bdc15da43ac"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ceec788e-98a4-45c1-86e2-a5d4c4b4f22a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8c6b768e-e290-4c28-b19a-1332ed7ab36c"), "Dentistry" },
                    { new Guid("df5dd338-2d1c-41c6-b738-d1b554befd03"), "Childcare" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_BillId",
                table: "Visit",
                column: "BillId",
                unique: true);
        }
    }
}
