using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class editprojectemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b1b4a7d-f840-4108-bc39-1fd5097e5689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d5a2443-7590-4ddb-91bf-e6863a5050f7");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EmployeeProject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa9b7543-c922-42f6-b328-ca9d543a6b0e", null, "Admin", "ADMIN" },
                    { "f28973a7-08bd-461a-b610-c1fe00a6fc0d", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa9b7543-c922-42f6-b328-ca9d543a6b0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f28973a7-08bd-461a-b610-c1fe00a6fc0d");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeProject");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b1b4a7d-f840-4108-bc39-1fd5097e5689", null, "Admin", "ADMIN" },
                    { "9d5a2443-7590-4ddb-91bf-e6863a5050f7", null, "Member", "MEMBER" }
                });
        }
    }
}
