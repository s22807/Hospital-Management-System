using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class trzynasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("2629c266-8a84-427b-83aa-00cc87ffcbef"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("bffe4a0a-ebaf-4e47-aa28-bbe1a7c9d21f"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("c05b8415-020d-4af4-9751-1e7c3e1e6257"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("dc36b8d2-4332-4b2c-af64-5b14eb98de32"));

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Bill",
                newName: "PaidAmount");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Bill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Bill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10461b59-2e75-4487-9376-d839ffde35ab"), "Dentistry" },
                    { new Guid("6bdea6a1-57c8-4a47-b074-04fe165d74de"), "Childcare" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("00843cea-7059-447f-93a7-bf465461c692"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 20, 52, 10, 43, DateTimeKind.Local).AddTicks(5387), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null },
                    { new Guid("8f307f67-09e7-4305-92b3-cc54724b95d7"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 20, 52, 10, 43, DateTimeKind.Local).AddTicks(5454), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("10461b59-2e75-4487-9376-d839ffde35ab"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6bdea6a1-57c8-4a47-b074-04fe165d74de"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("00843cea-7059-447f-93a7-bf465461c692"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("8f307f67-09e7-4305-92b3-cc54724b95d7"));

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "Bill",
                newName: "Cost");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2629c266-8a84-427b-83aa-00cc87ffcbef"), "Dentistry" },
                    { new Guid("bffe4a0a-ebaf-4e47-aa28-bbe1a7c9d21f"), "Childcare" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("c05b8415-020d-4af4-9751-1e7c3e1e6257"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 49, 43, 456, DateTimeKind.Local).AddTicks(6823), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null },
                    { new Guid("dc36b8d2-4332-4b2c-af64-5b14eb98de32"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 18, 49, 43, 456, DateTimeKind.Local).AddTicks(6887), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null }
                });
        }
    }
}
