using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84eaeba1-b9d0-4291-99dc-630ad2e6d376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e3969f-2886-4df0-9847-29df0d70914d");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aeb0289-04fe-49cc-9df0-9e04254c7c7a", null, "Admin", "ADMIN" },
                    { "579ff4d6-24dc-4ffd-9fb1-195339abccc9", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aeb0289-04fe-49cc-9df0-9e04254c7c7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "579ff4d6-24dc-4ffd-9fb1-195339abccc9");

            migrationBuilder.DropColumn(
                name: "EmployedAt",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84eaeba1-b9d0-4291-99dc-630ad2e6d376", null, "Member", "MEMBER" },
                    { "89e3969f-2886-4df0-9847-29df0d70914d", null, "Admin", "ADMIN" }
                });
        }
    }
}
