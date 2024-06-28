using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class szesnasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Announcements", "Name" },
                values: new object[,]
                {
                    { new Guid("2ae08e9f-d2d2-469b-872d-1ea5188eb035"), null, "Childcare" },
                    { new Guid("70c56bce-fbcf-4727-9b43-aa318a2f8c5f"), null, "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "DepartmentId", "Email", "FireDate", "FirstName", "HoursWorked", "LastName", "LoggedAt", "Password", "Pesel", "Role", "Salary", "Sex", "TagId", "Username", "VacationDays", "VisitTime" },
                values: new object[,]
                {
                    { new Guid("05ae5429-8e28-4bdd-8640-81a8608e201c"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", null, "Kowal", null, null, "12345678901", 1, 3000, true, null, null, 2, null },
                    { new Guid("0817d24f-fe3b-4cca-99fd-fc5d0827ac56"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebastian", null, "Internista", null, null, "12345678901", 3, 7500, true, null, null, 2, 15 },
                    { new Guid("2a31e871-3548-4101-b705-67ef44725736"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", null, "Goral", null, null, "12345678901", 1, 3000, true, null, null, 2, null },
                    { new Guid("2e450ed4-5329-4a4c-ac7a-8b97618c748e"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", null, "Internista", null, null, "12345678901", 3, 7500, true, null, null, 2, 15 },
                    { new Guid("89fc32f4-e076-48b7-9246-e29e29da01b7"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paweł", null, "Trainee", null, null, "12345678901", 0, 2500, true, null, null, 2, null },
                    { new Guid("a7a24bd1-3939-4f50-81e3-fbd96ba566f5"), new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Przemysław", null, "Admin", null, null, "12345678901", 2, 3400, true, null, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DeletedAt", "Email", "FathersName", "FirstName", "Insured", "LastName", "LoggedAt", "MothersName", "Password", "Pesel", "Sex", "Username" },
                values: new object[,]
                {
                    { new Guid("264c945d-8629-4dfe-95ea-dd93f16414d7"), new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 12, 58, 3, 960, DateTimeKind.Local).AddTicks(3971), null, null, null, "Jane", true, "Doe", null, null, null, "10987654321", false, null },
                    { new Guid("e9eab6c3-a0fe-46ee-b74e-1f74294a85e8"), new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 12, 58, 3, 960, DateTimeKind.Local).AddTicks(3925), null, null, null, "John", true, "Doe", null, null, null, "12345678901", true, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("2ae08e9f-d2d2-469b-872d-1ea5188eb035"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("70c56bce-fbcf-4727-9b43-aa318a2f8c5f"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("05ae5429-8e28-4bdd-8640-81a8608e201c"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("0817d24f-fe3b-4cca-99fd-fc5d0827ac56"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("2a31e871-3548-4101-b705-67ef44725736"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("2e450ed4-5329-4a4c-ac7a-8b97618c748e"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("89fc32f4-e076-48b7-9246-e29e29da01b7"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("a7a24bd1-3939-4f50-81e3-fbd96ba566f5"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("264c945d-8629-4dfe-95ea-dd93f16414d7"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: new Guid("e9eab6c3-a0fe-46ee-b74e-1f74294a85e8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");
        }
    }
}
