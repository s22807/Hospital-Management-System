using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dziesiata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("190da905-55ba-430a-aac1-7bdc15da43ac"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ceec788e-98a4-45c1-86e2-a5d4c4b4f22a"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Patient");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Visit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PatientId",
                table: "Bill",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Patient_PatientId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_PatientId",
                table: "Bill");

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

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Bill");

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
                    { new Guid("190da905-55ba-430a-aac1-7bdc15da43ac"), "Dentistry" },
                    { new Guid("ceec788e-98a4-45c1-86e2-a5d4c4b4f22a"), "Childcare" }
                });
        }
    }
}
