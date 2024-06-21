using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class szosta : Migration
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
                keyValue: new Guid("8218d18b-55e7-4cf2-aec4-57232fe899bd"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c8174460-f556-46a1-88e1-42a7140255a1"));

            migrationBuilder.AddColumn<int>(
                name: "HoursWorked",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitTime",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6edfd276-b25d-4017-b31e-48af6fd77af5"), "Childcare" },
                    { new Guid("a0552815-4577-4994-8a2c-a506f0a77e4c"), "Dentistry" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");
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
                keyValue: new Guid("6edfd276-b25d-4017-b31e-48af6fd77af5"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a0552815-4577-4994-8a2c-a506f0a77e4c"));

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "VisitTime",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8218d18b-55e7-4cf2-aec4-57232fe899bd"), "Childcare" },
                    { new Guid("c8174460-f556-46a1-88e1-42a7140255a1"), "Dentistry" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
