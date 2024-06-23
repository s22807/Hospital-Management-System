using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class czternasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomKey");

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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Visit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Visit");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "RoomKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RentedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomKey_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomKey_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomKey_EmployeeId",
                table: "RoomKey",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomKey_RoomId",
                table: "RoomKey",
                column: "RoomId");
        }
    }
}
