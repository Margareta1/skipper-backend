using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skipper_backend.Migrations
{
    /// <inheritdoc />
    public partial class edithiringpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f651bf7-fc36-42a5-ae23-e9a09de3279d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfc78945-56c7-4ac1-b393-d573fd14eb9d");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyProjectId",
                table: "HiringPost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "257d535b-6afe-4cd0-97e2-97e59813ee77", null, "Member", "MEMBER" },
                    { "8e4e1904-c5ae-4c19-a05a-b10fc99e7f12", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HiringPost_CompanyProjectId",
                table: "HiringPost",
                column: "CompanyProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HiringPost_CompanyProject_CompanyProjectId",
                table: "HiringPost",
                column: "CompanyProjectId",
                principalTable: "CompanyProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HiringPost_CompanyProject_CompanyProjectId",
                table: "HiringPost");

            migrationBuilder.DropIndex(
                name: "IX_HiringPost_CompanyProjectId",
                table: "HiringPost");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "257d535b-6afe-4cd0-97e2-97e59813ee77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4e1904-c5ae-4c19-a05a-b10fc99e7f12");

            migrationBuilder.DropColumn(
                name: "CompanyProjectId",
                table: "HiringPost");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f651bf7-fc36-42a5-ae23-e9a09de3279d", null, "Admin", "ADMIN" },
                    { "cfc78945-56c7-4ac1-b393-d573fd14eb9d", null, "Member", "MEMBER" }
                });
        }
    }
}
