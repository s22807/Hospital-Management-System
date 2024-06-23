using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Announcements", "Name" },
                values: new object[,]
                {
                    { new Guid("1bf07562-c800-4d6f-9c7e-bc12942b231e"), null, "Dentistry" },
                    { new Guid("e0846558-9a28-4843-aa79-32a0bbf97141"), null, "Childcare" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "DepartmentId", "Email", "FireDate", "FirstName", "HoursWorked", "LastName", "LoggedAt", "Password", "Pesel", "Role", "Salary", "Sex", "TagId", "Username", "VacationDays", "VisitTime" },
                values: new object[,]
                {
                    { new Guid("083a6287-d9c7-4f58-83b2-ad85c6affa4e"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", null, "Internista", null, null, "12345678901", 3, 7500, true, null, null, 2, 15 },
                    { new Guid("3a461a7b-220a-42fd-a670-cac196d05dfb"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", null, "Kowal", null, null, "12345678901", 1, 3000, true, null, null, 2, null },
                    { new Guid("57e3ff04-b01c-4ff1-a4ec-d434cd668cf3"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", null, "Goral", null, null, "12345678901", 1, 3000, true, null, null, 2, null },
                    { new Guid("7e174557-6432-4d6f-9bbd-10d63e229312"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebastian", null, "Internista", null, null, "12345678901", 3, 7500, true, null, null, 2, 15 },
                    { new Guid("a407776f-6d34-4acb-b7d5-a0000f227ea9"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przemysław", null, "Admin", null, null, "12345678901", 2, 3400, true, null, null, 2, null },
                    { new Guid("d8606002-e657-4c7d-b5bd-8bc098dce95d"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paweł", null, "Trainee", null, null, "12345678901", 0, 2500, true, null, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("7855dcea-6c59-482b-94ea-b33a9a483566"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 23, 42, 29, 626, DateTimeKind.Local).AddTicks(9022), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null },
                    { new Guid("d1ced38e-379f-485a-aab2-f82ee82bc3f8"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 23, 42, 29, 626, DateTimeKind.Local).AddTicks(9046), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1bf07562-c800-4d6f-9c7e-bc12942b231e"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("e0846558-9a28-4843-aa79-32a0bbf97141"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("083a6287-d9c7-4f58-83b2-ad85c6affa4e"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("3a461a7b-220a-42fd-a670-cac196d05dfb"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("57e3ff04-b01c-4ff1-a4ec-d434cd668cf3"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("7e174557-6432-4d6f-9bbd-10d63e229312"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("a407776f-6d34-4acb-b7d5-a0000f227ea9"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("d8606002-e657-4c7d-b5bd-8bc098dce95d"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("7855dcea-6c59-482b-94ea-b33a9a483566"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("d1ced38e-379f-485a-aab2-f82ee82bc3f8"));

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
    }
}
