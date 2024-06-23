using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pietnasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("89007f9b-46ed-43c8-9bc6-0123098a68d9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ced7a993-4f86-4ffc-8523-0f8b5703357c"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7909ee09-5e6f-487d-b067-d654e0fbab54"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("852bb25a-ea02-4fd1-9822-51dc3746fc6c"));

            migrationBuilder.AddColumn<string>(
                name: "Announcements",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Announcements", "Name" },
                values: new object[,]
                {
                    { new Guid("01c6c274-ac0b-48d9-ac75-727314b433f7"), null, "Dentistry" },
                    { new Guid("ff0e47b5-1a5e-4946-94ed-73302cecb200"), null, "Childcare" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("3e9d099e-a320-45d3-929d-51be6baa9aee"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 22, 48, 4, 646, DateTimeKind.Local).AddTicks(3258), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null },
                    { new Guid("c94dbf18-cf8b-4065-8e84-8131cb143634"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 22, 48, 4, 646, DateTimeKind.Local).AddTicks(3190), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("01c6c274-ac0b-48d9-ac75-727314b433f7"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ff0e47b5-1a5e-4946-94ed-73302cecb200"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("3e9d099e-a320-45d3-929d-51be6baa9aee"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("c94dbf18-cf8b-4065-8e84-8131cb143634"));

            migrationBuilder.DropColumn(
                name: "Announcements",
                table: "Department");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("89007f9b-46ed-43c8-9bc6-0123098a68d9"), "Childcare" },
                    { new Guid("ced7a993-4f86-4ffc-8523-0f8b5703357c"), "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("7909ee09-5e6f-487d-b067-d654e0fbab54"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 22, 1, 35, 775, DateTimeKind.Local).AddTicks(7406), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null },
                    { new Guid("852bb25a-ea02-4fd1-9822-51dc3746fc6c"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 22, 1, 35, 775, DateTimeKind.Local).AddTicks(7343), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null }
                });
        }
    }
}
