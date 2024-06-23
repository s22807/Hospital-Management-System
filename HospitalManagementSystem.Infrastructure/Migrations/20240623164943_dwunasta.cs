using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dwunasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill");

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

            migrationBuilder.RenameColumn(
                name: "IsCanceled",
                table: "Visit",
                newName: "IsCancelled");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill");

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
                name: "IsCancelled",
                table: "Visit",
                newName: "IsCanceled");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
