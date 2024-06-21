using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class osma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("13855dc4-b55d-47c0-883f-7293198386e0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7139ae82-69b7-45fd-b12a-a153606e11bb"));

            migrationBuilder.AlterColumn<int>(
                name: "VisitTime",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7fe94128-c4ce-4b05-b8ed-bdc685b1c5e9"), "Dentistry" },
                    { new Guid("8c97a692-ebf4-40bf-ba73-6f663cbd2e1c"), "Childcare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7fe94128-c4ce-4b05-b8ed-bdc685b1c5e9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8c97a692-ebf4-40bf-ba73-6f663cbd2e1c"));

            migrationBuilder.AlterColumn<int>(
                name: "VisitTime",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13855dc4-b55d-47c0-883f-7293198386e0"), "Dentistry" },
                    { new Guid("7139ae82-69b7-45fd-b12a-a153606e11bb"), "Childcare" }
                });
        }
    }
}
