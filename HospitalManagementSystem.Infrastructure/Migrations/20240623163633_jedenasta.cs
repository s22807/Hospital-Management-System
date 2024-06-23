using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class jedenasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("5966ce58-79e6-431c-a2ef-0b7b621af0a2"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("75f1f8b7-21c1-4c1f-bf74-1d78f8ce39b0"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("bc217e0d-5d6a-4c7d-8718-950ff8e8226e"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("cf6922bd-fb45-447d-9019-d3ff185ec6b8"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a44090e-5919-4ca4-9003-81bbef455de7"), "Childcare" },
                    { new Guid("b7483cd3-f84a-4cb6-b556-7751ac67f5c2"), "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("7c080508-559f-4959-bcff-2607923dd36e"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 36, 33, 704, DateTimeKind.Local).AddTicks(5079), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null },
                    { new Guid("98e51571-025d-455d-af35-0730654efed5"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 36, 33, 704, DateTimeKind.Local).AddTicks(5145), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("0a44090e-5919-4ca4-9003-81bbef455de7"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("b7483cd3-f84a-4cb6-b556-7751ac67f5c2"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7c080508-559f-4959-bcff-2607923dd36e"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("98e51571-025d-455d-af35-0730654efed5"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Patient");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5966ce58-79e6-431c-a2ef-0b7b621af0a2"), "Dentistry" },
                    { new Guid("75f1f8b7-21c1-4c1f-bf74-1d78f8ce39b0"), "Childcare" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Pesel", "Sex" },
                values: new object[,]
                {
                    { new Guid("bc217e0d-5d6a-4c7d-8718-950ff8e8226e"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 28, 59, 67, DateTimeKind.Local).AddTicks(3572), null, null, "John", true, "Doe", null, null, "12345678901", true },
                    { new Guid("cf6922bd-fb45-447d-9019-d3ff185ec6b8"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 28, 59, 67, DateTimeKind.Local).AddTicks(3641), null, null, "Jane", true, "Doe", null, null, "10987654321", false }
                });
        }
    }
}
