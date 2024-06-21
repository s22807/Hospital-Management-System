using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class piata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("0855bfa1-e8b2-4b60-8292-6a14d29d6b34"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("31a9a8a5-c3c4-435c-a331-cad4e9518149"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8218d18b-55e7-4cf2-aec4-57232fe899bd"), "Childcare" },
                    { new Guid("c8174460-f556-46a1-88e1-42a7140255a1"), "Dentistry" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_TagId",
                table: "Visit",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TagId",
                table: "Room",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TagId",
                table: "Employee",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tag_TagId",
                table: "Employee",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Tag_TagId",
                table: "Room",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Tag_TagId",
                table: "Visit",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Tag_TagId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Tag_TagId",
                table: "Visit");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Visit_TagId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Room_TagId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TagId",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8218d18b-55e7-4cf2-aec4-57232fe899bd"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("c8174460-f556-46a1-88e1-42a7140255a1"));

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "Visit",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0855bfa1-e8b2-4b60-8292-6a14d29d6b34"), "Dentistry" },
                    { new Guid("31a9a8a5-c3c4-435c-a331-cad4e9518149"), "Childcare" }
                });
        }
    }
}
