using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class trzecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7f23eef5-9198-4169-b29b-e7a7ca968fb8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8cadd26f-d13b-4c1e-85b1-e97fc935112d"));

            migrationBuilder.AddColumn<bool>(
                name: "Insured",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7b22190a-a1d6-47db-bbb5-698e36a0760c"), "Childcare" },
                    { new Guid("c7a69a1d-4180-4a08-8fe9-4fee344e9c46"), "Dentistry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7b22190a-a1d6-47db-bbb5-698e36a0760c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c7a69a1d-4180-4a08-8fe9-4fee344e9c46"));

            migrationBuilder.DropColumn(
                name: "Insured",
                table: "Patient");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7f23eef5-9198-4169-b29b-e7a7ca968fb8"), "Childcare" },
                    { new Guid("8cadd26f-d13b-4c1e-85b1-e97fc935112d"), "Dentistry" }
                });
        }
    }
}
