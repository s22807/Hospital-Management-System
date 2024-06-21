using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dziewiata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7fe94128-c4ce-4b05-b8ed-bdc685b1c5e9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8c97a692-ebf4-40bf-ba73-6f663cbd2e1c"));

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "Visit",
                newName: "VisitStartDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8c6b768e-e290-4c28-b19a-1332ed7ab36c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("df5dd338-2d1c-41c6-b738-d1b554befd03"));

            migrationBuilder.RenameColumn(
                name: "VisitStartDate",
                table: "Visit",
                newName: "VisitDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Visit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7fe94128-c4ce-4b05-b8ed-bdc685b1c5e9"), "Dentistry" },
                    { new Guid("8c97a692-ebf4-40bf-ba73-6f663cbd2e1c"), "Childcare" }
                });
        }
    }
}
